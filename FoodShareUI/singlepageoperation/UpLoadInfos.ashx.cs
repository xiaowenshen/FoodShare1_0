using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
namespace FoodShareUI.singlepageoperation
{
    /// <summary>
    /// UpLoadInfo 的摘要说明
    /// </summary>
    public class UpLoadInfos : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //获取上传的文件
            //HttpPostedFile file = context.Request.Files[0];
            HttpPostedFile file = context.Request.Files[0];
            if (file.ContentLength > 0)
            {
                //获得文件名
                string FileName = Path.GetFileName(file.FileName);
                //获取拓展名
                string FileExten = Path.GetExtension(FileName);
                //判断是否属于图片格式
                picModel pc = new picModel();

                if (pc.pic.Contains(FileExten))
                {
                    //对文件重命名，解决文件名重复问题
                    //文件基础目录
                    // string nameBase = @"D:\C#代码\asp_net_Web3-tier\WebUI\UploadImg\";
                    //文件名
                    string newfileName = Guid.NewGuid().ToString();
                    //文件目录
                    string dir = "/images/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    //创建文件夹
                    if (!Directory.Exists(context.Request.MapPath(dir)))
                    {
                        Directory.CreateDirectory(context.Request.MapPath(dir));
                    }
                    //完整路径名
                    string fulname = dir + newfileName + FileExten;
                    //可以上传,保存文件
                    file.SaveAs(context.Request.MapPath(fulname));
                    //创建图片水印
                    using (Image img = Image.FromStream(file.InputStream))//从输入流中获取图片
                    //   using(Image img=Image.FromFile(context.Request.MapPath(fulname)))
                    {
                        using (Bitmap map = new Bitmap(img.Width, img.Height))//根据上传成功的图片创建的img，宽度高度由此决定
                        {
                            //创建画笔
                            using (Graphics g = Graphics.FromImage(map))
                            {
                                g.DrawImage(img, 0, 0, img.Width, img.Height);
                                g.DrawString("一起用餐吧", new Font("微软雅黑", 13.0f, FontStyle.Bold), Brushes.White, new PointF(img.Width - 170, img.Height - 30));
                                //为画布创建名字
                                string mapname = "map" + Guid.NewGuid().ToString();
                                //添加作品
                                MyWorksBLL mbll = new MyWorksBLL();
                                MyWorks work = new MyWorks();
                                work.WTitle = context.Request["wtitle"].ToString();
                                work.path = fulname;
                                work.isdel = false;
                                work.UId = ((UserInfo)context.Session["uinfo"]).UId;
                                work.introduce = context.Request["wintroduce"].ToString();
                                work.addtime = DateTime.Now;
                                if(mbll.UploadWork(work))
                                {
                                    //ok
                                    map.Save(context.Request.MapPath("/images/" + mapname + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                                    context.Response.Write("<script>alert('上传成功')</script>");
                                    context.Response.Redirect("mymainpage.aspx");
                                }
                                else
                                {
                                    //error
                                    context.Response.Write("<script>alert('上传失败！')</script>");
                                    context.Response.Redirect("SubmitInfo.aspx");
                                }
                               
                            }
                        }

                    }


                }
                else
                {
                    //不能上传
                    context.Response.Write("只能上传图片！");
                }

            }
            else
            {
                context.Response.Write("<script>alert('请选择上传的图片！')</script>");
            }

        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}