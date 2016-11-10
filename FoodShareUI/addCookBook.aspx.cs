using FoodShareBLL;
using FoodShareCOMMON;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodShareUI
{
    public partial class addCookBook : CheckSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public int Count { get; set; }
        protected void Submit_Click(object sender, EventArgs e)
        {
            CookBookBLL cbll = new CookBookBLL();
            CookBook cb = new CookBook();
            HttpPostedFile file = Request.Files[0];
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
                                LoadCookBook(cb, fulname);
                                if (cbll.AddCookBook(cb))
                                {
                                    //ok
                                    map.Save(Request.MapPath("/images/" + mapname + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                                    Response.Write("<script>alert('上传成功')</script>");
                                    Response.Redirect("mymainpage.aspx");
                                }
                                else
                                {
                                    //error
                                    Response.Write("<script>alert('上传失败！')</script>");
                                    Response.Redirect("addCookBook.aspx");
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

        private void LoadCookBook(CookBook cb , string fulname)
        {
           
            cb.addtime = DateTime.Now;
            cb.isdel = false;
            cb.path = fulname;
            cb.UId = ((UserInfo)Session["uinfo"]).UId;
            cb.stepcount = Session["count"] == null ? -1 : Convert.ToInt32(Session["count"]) ;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= cb.stepcount; i++)
            {
                sb.Append(Request.Form["introduce" + i].ToString() + '$' );
            }
            cb.CContent = sb.ToString();
            cb.CIntroduce = Request.Form["CIntroduce"].ToString();
            cb.CTitle = Request.Form["CTitle"].ToString();
        }
    }
}