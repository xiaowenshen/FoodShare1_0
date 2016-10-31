using FoodShareCOMMON;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodShareBLL;
namespace FoodShareUI.showpage
{
    public partial class addstrategy : CheckSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files[0];
            if (file.ContentLength > 0)
            {
                MyStrategyBLL mbll = new MyStrategyBLL();

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
                    if (!Directory.Exists(Request.MapPath(dir)))
                    {
                        Directory.CreateDirectory(Request.MapPath(dir));
                    }
                    //完整路径名
                    string fulname = dir + newfileName + FileExten;
                    //可以上传,保存文件
                    file.SaveAs(Request.MapPath(fulname));
                    //创建图片水印
                    using (System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream))//从输入流中获取图片
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

                                MyStrategy ms = new MyStrategy();
                                LoadMyStrategy(ms, fulname);
                                if (mbll.Add(ms))
                                {
                                    //ok
                                    map.Save(Request.MapPath("/images/" + mapname + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                                    Response.Write("<script>alert('上传成功')</script>");
                                    Response.Redirect(Page.ResolveUrl("~/mymainpage.aspx"));
                                }
                                else
                                {
                                    //error
                                    Response.Write("<script>alert('上传失败！')</script>");
                                    Response.Redirect(Page.ResolveUrl("~/showpage/addstrategy.aspx"));
                                }

                            }
                        }

                    }


                }
                else
                {
                    //不能上传
                    Response.Write("只能上传图片！");
                }

            }
            else
            {
                Response.Write("<script>alert('请选择上传的图片！')</script>");
            }



        }
        /// <summary>
        /// 加载ms对象
        /// </summary>
        /// <param name="ms">MyStrategy对象</param>
        /// <param name="fulname">图片保存路径</param>
        private void LoadMyStrategy(MyStrategy ms , string fulname)
        {
            ms.addtime = DateTime.Now;
            ms.isdel = false;
            ms.Path = fulname;
            ms.SContent = Request.Form["addcontent"] != null ? Request.Form["addcontent"].ToString() : string.Empty;
            ms.STitle = Request.Form["title"] != null ? Request.Form["title"].ToString() : string.Empty;
            UserInfo user = (UserInfo)Session["uinfo"];
            ms.UId = user.UId;
            ms.Uname = user.name;
            

        }


        protected void returnmypage_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveUrl("~/mymainpage.aspx"));

        }
    }
}