<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mymainpage.aspx.cs" Inherits="FoodShareUI.mymainpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <title>个人主页</title>
        <meta name="description" content=""/>
        <script src="js/jquery-1.11.0.min.js"></script>
        <script src="js/jquery.easyui.min.js"></script>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <link href="css/pageStyle.css" rel="stylesheet" />
        <link rel="stylesheet" href="css/normalize.css"/>
        <link rel="stylesheet" href="css/font-awesome.css"/>
        <link rel="stylesheet" href="css/bootstrap.min.css"/>
        <link rel="stylesheet" href="css/templatemo-style.css"/>
        <link href="css/relationship.css" rel="stylesheet" />
        <link href="css/checkbox.css" rel="stylesheet" />
        <script src="js/vendor/modernizr-2.6.2.min.js"></script>
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all"/>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Horse Farm Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
    Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--Google Fonts-->
    <link href='https://fonts.googleapis.com/css?family=Baumans' rel='stylesheet' type='text/css'/>
    <link href='https://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,300italic,700' rel='stylesheet' type='text/css'/>
        <script type="text/javascript">
        $(function () {
           //添加作品
            $("#addMyWork").click(function () {
                location.href = "SubmitInfo.aspx";
            })
            //添加菜谱
            $("#addCookBook").click(function () {
                location.href = "addCookBook.aspx";
            })
            //加载个人作品
            LoadWorks(1)
            //加载攻略列表
            LoadStrategyInfo(1);
            //加载菜单
            LoadMenuInfo(1);
            //加载菜谱
            LoadCookBook(1);
            //加载收藏
            LoadCollect();
            //加载关注
            LoadFocus(1);
            //加载留言
            LoadComment(1);
            //显示欢迎
            displaycookmenu()
            //testlist
            

        })
        function loadCookBookList(index)
        {
               $.post("mymainpageoperation/ShowMenuList.ashx", { }, function (data) {
                
                var jsondata = data;
                var jlength = jsondata.SList == null ? 0 : jsondata.SList.length;
                var string = "";

                for (var i = 0; i < jlength; i++) {
                    string = string + "<tr class=\"active\"><td>" + "<input type='checkbox' name='" + jsondata.SList[i].MenuName + "' value=' " + jsondata.SList[i].MenuName + "'/>" + "</td><td>" + "<label>" + jsondata.SList[i].MenuName + "<label/></td></tr>";

                }
                string = string + "<br/><input type='button' class = 'btn btn-1 btn-warning' value='确认添加'>"
                alert(string);
                $.parseHTML(string);
                $("#showmenulist").html(string);
               }, "json");

        }
      
            //编辑作品
        function editwork(id)
        {
            windows.open( "showpage/editWork.aspx?wid=" + id);
        }
            //删除作品
        function deletework(id)
        {

            if (!confirm("确认要删除吗？"))
                return false;
            else
            {
                $.post("mymainpageoperation/deleteWork.ashx", { "wid": id }, function (data) {
                    if (data == "1") {
                        alert("删除成功！");
                        LoadWorks(1);
                    }
                    else {
                        alert("删除失败，请稍后再试！");
                    }

                });
            }
        }
            //加载作品
        function LoadWorks(index)
        {
            var string = "";
            $.post("mymainpageoperation/showWorks.ashx", { "worksindex": index }, function (data) {
                var jsondata = $.parseJSON(data);
                var jlength = jsondata.SList == null ? 0 : jsondata.SList.length;
                var string = "";
                for (var i = 0; i < jlength; i++)
                {
                    string += " <div class=\"col-md-4 col-sm-6\">　"+
                                        "<div class=\"project-item\">"+
                                            "<img src='" + jsondata.SList[i].path+ "' style=\"width:433px;height:320px\" />" +
                                            "<div class=\"project-hover\">"+
                                                "<div class=\"inside\">"+
                                                    "<h5><a href=''>"+ jsondata.SList[i].WIitle+"</a></h5>"+
                                                    "<p>"+ jsondata.SList[i].introduce+"</p>"+
                                                "</div>"+
                                            "</div>"+
                                        "</div>" +
                                        "<input type=\"button\" id=\"addMyWork\" onclick='editwork(" + jsondata.SList[i].WId + ")' class=\"btn btn-1 btn-primary\" value =\"编辑\"/> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" +
                                         "        <input type=\"button\" onclick ='deletework("+ jsondata.SList[i].WId+")' class=\"btn btn-1 btn-danger\" value =\"删除\"/>"+
                                    "</div>";
                }
                $("#workscontent").html(string);
                $("#workspagebar").html(jsondata.PageBar );
               worksPageBar();
            }, "text");
        }
            //作品的页码
        function worksPageBar()
        {
            $(".workspages").click(function () {
                var index = $(this).attr("href").split("=")[1];
                LoadWorks(index);
                return false;
            });
        }
            //添加留言
        function leaveComment(id)
        {
            var cdata = $("#msg").val();
            if(cdata.trim() == "")
            {
                alert("留言不能为空！");
            }
            else
            {
                $.post("mymainpageoperation/addComment.ashx", { "msg": cdata, "u2id": id }, function (data) {

                    if (data == "OK") {
                        alert("留言成功!");
                        LoadComment(1);
                    }
                    else if (data == "UNRES") {
                        alert("请登录!");
                    }
                    else {
                        alert("服务器繁忙，请稍后再试！");
                    }

                });
            }
        
        }
            //加载留言
        function LoadComment(index)
        {
            $.post("mymainpageoperation/showComment.ashx", { "commentindex": index }, function (data) {
                var jsondata = $.parseJSON(data);
                var jlength = jsondata.SList == null ? 0 : jsondata.SList.length;
                var string = "<h3>Comments</h3>";
                for (var i = 0; i < jlength; i++) {
                    if (i % 2 == 0)
                    {
                        string = string + "<div class=\"media\">" +
                         "<div class=\"media-body\">" +
                            " <h4 class=\"media-heading\">" + jsondata.SList[i].U1name+ "</h4>" +
                             "<p>" + jsondata.SList[i].comment+ "</p>" +
                             "</div>" +
                      " <div class=\"media-right\">" +
                         "<a href='#'>" +
                             "<img src=\"" + jsondata.SList[i].U1path + "\" alt=''  style=\"width:70px;height:70px\" /> </a>" +
                            "</div>" +
                          " </div>";
                    }
                    else
                    {
             
                        string = string + "<div class=\"media\">" +
                         "<div class=\"media-left\">" +
                          "<a href='#'>" +
                             "<img src=\"" + jsondata.SList[i].U1path + "\" alt=''  style=\"width:70px;height:70px\" /> </a>" +
                            "</div>" +
                            " <div class=\"media-body\">" +
                            " <h4 class=\"media-heading\">" + jsondata.SList[i].U1name + "</h4>" +
                             "<p>" + jsondata.SList[i].comment + "</p>" +
                             "</div>" +
                          " </div>";
                    }
                }
                var lvcomment = "<textarea name=\"msg\" id=\"msg\" placeholder=\"Message\"></textarea>" +
							"<input type=\"button\" onclick=\"leaveComment("+jsondata.UID+")\"  id=\"leavecomment\" class=\"btn btn-1 btn-warning\" value=\"Send\"/>";
                $("#commentcontent").html(string);
                $("#commentpagebar").html(jsondata.PageBar);
                $("#lvcomment").html(lvcomment);
                commentPageBar();
            }, "text")
        }
            //评论页码
        function commentPageBar() {
            $(".commentpages").click(function () {
                var index = $(this).attr("href").split("=")[1];
                LoadComment(index);
                return false;
            });
        }
            //加载关注
        function LoadFocus(focusindex)
        {
            $.post("mymainpageoperation/showFocus.ashx", { "focusindex": focusindex }, function (data) {
                //$("#focuscontent").remove();
                var jsondata = $.parseJSON(data);
                var jlength = jsondata.SList.length;
                var string = "";
                for (var i = 0; i < jlength; i++) {
                    string = string +
                        "<div class=\"col-sm-6\"><dl>"+
                                      "<dt><a href='singlepage.aspx?cid=" + jsondata.SList[i].UId2 +"' target='_blank'><img src='"+jsondata.SList[i].U2path+"'   /></a></dt>"+
                                      "<dd>"+
                                        "<h4><a href='singlepage.aspx?cid=" + jsondata.SList[i].UId2 + "'  target='_blank' id='" + jsondata.SList[i].UId2 + "' title='" + jsondata.SList[i].U2name + "' class='user_name'>" + jsondata.SList[i].U2name + "</a></h4>" +
                                        "<p>"+jsondata.SList[i].U2Introduce+"</p>"+
                                        "<div class=\"clearfix\">"+
                                         " <div class=\"pull-left\">"+
                                          "</div>"+
                                          "<div class=\"pull-right\">"+
                                           " <div class=\"follow \">"+
                                            "  <div class=\"text\" onclick=\"unfollow("+jsondata.SList[i].FocusId+")\">取消关注</div>"+
                                             " <div class=\"icon\"></div>"+
                                            "</div>"+
                                          "</div>"+
                                        "</div>"+
                                      "</dd>"+
                                    "</dl>"+
                                  "</div>"
                }
                $("#focuscontent").html(string);
                $("#foucuspagebar").html(jsondata.PageBar);
                FocusPageBar();

            });
        }

        function FocusPageBar()
        {
            $(".focuspages").click(function () {
               var index = $(this).attr("href").split("=")[1];
                LoadFocus(index);
                return false;
            });
        }


        //取消关注
        function unfollow(fid)
        {
            if (!confirm("确定要取消关注吗？"))
            {

            }
            else
            {
                $.post("mymainpageoperation/deleteFocus.ashx", { "fid": fid }, function (data) {
                    if (data == "OK") {
                        alert("取消关注成功！");
                        LoadFocus(1);//后期可以改成当前页
                    }
                    else {
                        alert("取消失败，请稍后再试！");
                    }

                });

            }
         
        }
        //加载收藏
        function LoadCollect()
        {
            $.post("mymainpageoperation/showCollection.ashx", {}, function (data) {
                var jsondata = $.parseJSON(data);
                var jlength = jsondata.SList.length;
                var string = "";
                for (var i = 0; i < jlength; i++) {
                    string = string + "<div class=\"col-md-4 col-sm-6\"><div class=\"project-item\" ><img src='" + jsondata.SList[i].path + "' style=\"width:433px;height:320px\"  /><div class=\"project-hover\">" +
                                                "<div class=\"inside\">" +
                                                    "<h5><a target='_blank' href=\"showpage/showcookbook.aspx?cid=" + jsondata.SList[i].CId +"&op=0"+ "\">" + jsondata.SList[i].CTitle + "</a></h5>" +
                                                    "<p>" + jsondata.SList[i].CIntroduce + "</p>" +
                                               " </div>" +
                                           " </div>" +
                                     " </div><input type=\"button\"  menuid =\"" + jsondata.SList[i].CId + "\" name=\"deletecollection\"  class=\"btn btn-1 btn-danger\" value =\"删除此菜谱\" /></div>";
                }
                $("#collectcontent").html(string);
                BindDelCollect();
            }, "text");
           
            

        }
        //把菜谱添加至菜单
        function addtocookbook(cid)
        {

        }

        //加载菜谱
        function LoadCookBook(cookbookindex)
        {
           // $("#cookbookcontent").remove();
            $.post("mymainpageoperation/showCookBook.ashx", { "cbindex": cookbookindex }, function (data) {
                var jsondata = $.parseJSON(data);
                var jlength = jsondata.SList.length;
                var string = "";
                for (var i = 0; i < jlength; i++) 
                {
                    string = string + "<div class=\"col-md-4 col-sm-6\"><div class=\"project-item\" ><img src='" + jsondata.SList[i].path + "' style=\"width:433px;height:320px\"  /><div class=\"project-hover\">" +
                                                "<div class=\"inside\">" +
                                                    "<h5><a target='_blank' href=\"showpage/showcookbook.aspx?cid=" + jsondata.SList[i].CId +"&op=1"+ "\">" + jsondata.SList[i].CTitle + "</a></h5>" +
                                                    "<p>" + jsondata.SList[i].CIntroduce + "</p>" +
                                               " </div>" +
                                           " </div>" +
                                     " </div>" + "<input type=\"button\" onclick=\"addtocookbook(" + jsondata.SList[i].CId + ")\" class=\"btn btn-1 btn-info\" value =\"添加至菜单\" />" +
                                       " <input type=\"button\"  menuid =\"" + jsondata.SList[i].CId + "\" name=\"addtocollection\"  class=\"btn btn-1 btn-info\" value =\"添加至收藏夹\" /></div>";
                }
                $("#cookbookcontent").html(string);
               // alert(string);
                $("#cookbookpagebar").html(jsondata.PageBar);

                CookPageBar();
                //绑定添加菜谱至收藏夹
                BindAdd();
                BindDel();
            }, "text");
        }
        //加载分页条
        function CookPageBar()
        {
            $(".cbpages").click(function () {
                var cbindex = $(this).attr("href").split("=")[1];
                LoadCookBook(cbindex);
                //防止跳转
                return false;
            });
        }
        //绑定菜谱管理
        function BindManageCookBook()
        {
            $("#managecookbook").click(ManageCookBook());
        }
        //管理菜谱
        function ManageCookBook()
        {
            displaymanagecookbook();
            LoadManageCookBook(1);
        }
        //删除菜谱
        function deleteCookBook()
        {
            var cid = $(this).attr("cid");
            if(!confirm("确定要删除吗？111"))
            {
                return false;
            }
            else
            {
                $.post("mymainpageoperation/deleteCookBook.ashx", { "cid": cid }, function (data) {
                    if(data == "1")
                    {
                        alert("删除成功！");
                        LoadManageCookBook(1);
                    }

                });
            }
        }
        //绑定删除菜谱
        function BindManageDel()
        {
            $(".cbdel").click(function () {

                var cid = $(this).attr("cid");
                if (!confirm("确定要删除吗？")) {
                    return false;
                }
                else {
                    $.post("mymainpageoperation/deleteCookBook.ashx", { "cid": cid }, function (data) {
                        if (data == "1") {
                            alert("删除成功！");
                            LoadManageCookBook(1);
                        }

                    });
                }
            });
        }
        //加载管理页面
        function LoadManageCookBook(cookbookindex)
        {
            $("#CookBooklist tr:gt(0)").remove();
            $.post("mymainpageoperation/showCookBook.ashx", { "cbindex": cookbookindex }, function (data) {
                var jsondata = $.parseJSON(data);
                var jlength = jsondata.SList.length;
                var string = "";
                for (var i = 0; i < jlength; i++)
                {
                         $("<tr class=\"active\"><td>" + jsondata.SList[i].CTitle + "</td><td>" +
                        ChangeDateFormat(jsondata.SList[i].addtime) + "</td><td>" + "<a target=\"_blank\" href='<%=Page.ResolveUrl("~/showpage/showcookbook.aspx")%>?cid=" + jsondata.SList[i].CId + "&op=0" +"' class='detail'>详情</a>" + "" +
                        "</td><td><a target=\"_blank\" href='<%=Page.ResolveUrl("~/showpage/showcookbook.aspx")%>?cid=" + jsondata.SList[i].CId + "&op=1" + "' class='edit'>编辑</a></td>" + "<td><a href='javascript:void(0)' cid='" + jsondata.SList[i].CId + "' class='cbdel'>删除</a></td>" + "</tr>").appendTo("#CookBooklist");
                }
                $("#cbookpagebar").html(jsondata.PageBar);
                BindManageDel();
                ManageCookBookPageBar();
            }, "text");
        }

         //管理菜谱页码条
        function ManageCookBookPageBar()
        {
            $(".cbpages").click(function () {
                var cbindex = $(this).attr("href").split("=")[1];
                LoadManageCookBook(cbindex);
                //防止跳转
                return false;
            });
        } 
        //加载攻略
        function LoadStrategyInfo(strategypageindex)
        {

            //清除数据
            $("#Strategylist tr:gt(0)").remove();
            $.post("mymainpageoperation/ShowMyStrategy.ashx", { "mspageindex": strategypageindex }, function (data) {
                var jsondata = $.parseJSON(data);
                var jlength = jsondata.SList.length;
                for (var i = 0; i < jlength; i++) {
                    $("<tr class=\"active\"><td>" + jsondata.SList[i].STitle + "</td><td>" + jsondata.SList[i].Uname + "</td><td>" +
                        ChangeDateFormat(jsondata.SList[i].addtime) + "</td><td>" + "<a target=\"_blank\" href='<%=Page.ResolveUrl("~/showpage/showstrategy.aspx")%>?Sid="+jsondata.SList[i].SId+"' class='detail'>详情</a>" + "" +
                        "</td><td><a target=\"_blank\" href='<%=Page.ResolveUrl("~/showpage/editstrategy.aspx")%>?Sid=" + jsondata.SList[i].SId + "' class='edit'>编辑</a></td>" + "<td><a href='javascript:void(0)' sid='" + jsondata.SList[i].SId + "' class='del'>删除</a></td>" + "</tr>").appendTo("#Strategylist");
                }
                $("#mspagebar").html(jsondata.PageBar);
                StrategyPageBar();
                BindDel();
                BindAdd();
            })
        }
        
        //显示页码条
        function StrategyPageBar() {
            $(".mspages").click(function () {
                var pageindex = $(this).attr("href").split("=")[1];
                //清除数据
                $("#Strategylist tr:gt(0)").remove();
                LoadStrategyInfo(pageindex);
                //不发生跳转
                return false;
            });
        }


        // //加载菜单
        function LoadMenuInfo(menupageindex){
            $.post("mymainpageoperation/ShowMenu.ashx", { "menupageindex": menupageindex }, function (data) {
                
                var jsondata = data ;//$.parsejson(data);
                var jlength = jsondata.SList.length;
                var string = "<div class=\"comments-top\"><h3>CookMenu</h3>";
                //alert(jsondata.Index);
                for (var i = 0; i < jlength; i++) {
                    string = string + "<div class=\"media\">" +
                                        "<div class=\"media-left\">" +
                                        " <a href=''>" +
                      "<img src='" + jsondata.SList[i].path + "' alt='' style=\"width:100px;height:100px\">" +
                  "</a>" +
                "</div>" +
                "<div class=\"media-body\">" +
                 " <h4 class=\"media-heading\">介绍</h4>" +
                 " <p>" + jsondata.SList[i].MenuIntroduce + "</p>" +
                 "...<a target='_blank' href='<%=Page.ResolveUrl("~/showpage/showmenu.aspx")%>?MenuId=" + jsondata.SList[i].MenuId + "' >详情</a></div></div>";
             
                 
                }
                string = string + "</div>";
                BindAdd();
                $.parseHTML(string);
                $("#showmenu").html(string);
                $("#menupagebar").html(jsondata.PageBar);
                MenuPageBar();
            },"json");
        }
            //显示页码条
            function  MenuPageBar()
            {
                $(".menupages").click(function ()
                {
                    var menupageindex = $(this).attr("href").split("=")[1];
                  //  //清除数据   
                  //  $("#showmenu").remove();
                    LoadMenuInfo(menupageindex);
                    //不发生跳转
                    return false;
                });
            }
        //删除收藏
            function BindDelCollect()
            {
                $("input[name='deletecollection']").bind('click', function () {
                    if (!confirm("确认要删除吗？"))
                        return false;
                    else {
                        var menuid = $(this).attr("menuid");
                        $.post("mymainpageoperation/deleteCollection.ashx", { "menuid": menuid }, function (data) {
                            if (data == "OK") {
                                alert("删除成功！")
                                LoadCollect();
                            }
                            else {
                                alert("删除失败！请稍后再试！");
                            }
                        }, "text");
                    }

                });

            }
        //删除攻略
        function BindDel() {
            
            $('.del').click(function () {
                var sid = $(this).attr("sid");
                if (!confirm("确认要删除吗？"))
                    return false;
                else {
                    $.post("showpage/DelStrategy.ashx", { "sid": sid }, function (data) {
                        if (data == "ok") {
                            //清楚原有表格数据
                            //把tr从第一行的数据开始 全部清除
                            $("#Strategylist tr:gt(0)").remove();
                            //重新加载
                            LoadStrategyInfo();
                            alert("删除成功！");
                        }
                    });
                }

            });
        }
        //添加到收藏夹
        function AddToCollect()
        {
            $("input[name='addtocollection']").bind('click', function () {
                var menuid = $(this).attr("menuid");
                $.post("mymainpageoperation/addtocollection.ashx", { "menuid": menuid }, function (data) {
                    if (data == "OK") {
                        alert("添加成功！");
                        LoadCollect();
                    }
                    else if (data == "EXIST") {
                        alert("此菜谱已经添加过，请勿重复添加！");
                    }
                    else {
                        alert("添加失败，请稍后再试！");
                    }
                }, "text");
            });
        }
        //绑定添加项

        function BindAdd()
        {
            AddToCollect();
        }

        function displaywellcome()
        {
            $("#top").css("display", "block");
            $("#myworks").css("display", "block");
            $("#newmycookbook").css("display", "none");
            $("#mystrategy").css("display", "none");
            $("#cookmenu").css("display", "none");
            $("#mycollect").css("display", "none");
            $("#myconcern").css("display", "none");
            $("#myboard").css("display", "none");
            
            $("#managecbook").css("display", "none");
        }

        function displaywork() {
            $("#top").css("display", "block");
            $("#myworks").css("display", "block");
            $("#newmycookbook").css("display", "none");
            $("#mystrategy").css("display", "none");
            $("#cookmenu").css("display", "none");
            $("#mycollect").css("display", "none");
            $("#myconcern").css("display", "none");
            $("#myboard").css("display", "none");
            $("#managecbook").css("display", "none");
        }

        function displaycookbook() {
            $("#top").css("display", "none");
            $("#myworks").css("display", "none");
            $("#newmycookbook").css("display", "block");
            $("#mystrategy").css("display", "none");
            $("#cookmenu").css("display", "none");
            $("#mycollect").css("display", "none");
            $("#myconcern").css("display", "none");
            $("#myboard").css("display", "none");
            $("#managecbook").css("display", "none");
        }

        function displaystrategy() {
            $("#top").css("display", "none");
            $("#myworks").css("display", "none");
            $("#newmycookbook").css("display", "none");
            $("#mystrategy").css("display", "block");
            $("#cookmenu").css("display", "none");
            $("#mycollect").css("display", "none");
            $("#myconcern").css("display", "none");
            $("#myboard").css("display", "none");
            $("#managecbook").css("display", "none");
        }

        function displaycookmenu() {
            $("#top").css("display", "none");
            $("#myworks").css("display", "none");
            $("#newmycookbook").css("display", "none");
            $("#mystrategy").css("display", "none");
            $("#cookmenu").css("display", "block");
            $("#mycollect").css("display", "none");
            $("#myconcern").css("display", "none");
            $("#myboard").css("display", "none");
            $("#managecbook").css("display", "none");
            loadCookBookList(1);
        }

        function displaycollection() {
            $("#top").css("display", "none");
            $("#myworks").css("display", "none");
            $("#newmycookbook").css("display", "none");
            $("#mystrategy").css("display", "none");
            $("#cookmenu").css("display", "none");
            $("#mycollect").css("display", "block");
            $("#myconcern").css("display", "none");
            $("#myboard").css("display", "none");
            $("#managecbook").css("display", "none");
        }

        function displayfocus() {
            $("#top").css("display", "none");
            $("#myworks").css("display", "none");
            $("#newmycookbook").css("display", "none");
            $("#mystrategy").css("display", "none");
            $("#cookmenu").css("display", "none");
            $("#mycollect").css("display", "none");
            $("#myconcern").css("display", "block");
            $("#myboard").css("display", "none");
            $("#managecbook").css("display", "none");
        }

        function displaycomment() {
            $("#top").css("display", "none");
            $("#myworks").css("display", "none");
            $("#newmycookbook").css("display", "none");
            $("#mystrategy").css("display", "none");
            $("#cookmenu").css("display", "none");
            $("#mycollect").css("display", "none");
            $("#myconcern").css("display", "none");
            $("#myboard").css("display", "block");
            $("#managecbook").css("display", "none");
        }

        function displaymanagecookbook()
        {
            $("#top").css("display", "none");
            $("#myworks").css("display", "none");
            $("#newmycookbook").css("display", "none");
            $("#mystrategy").css("display", "none");
            $("#cookmenu").css("display", "none");
            $("#mycollect").css("display", "none");
            $("#myconcern").css("display", "none");
            $("#myboard").css("display", "none");
            $("#managecbook").css("display", "block");
           
        }
        //将序列化成json格式后日期(毫秒数)转成日期格式
        function ChangeDateFormat(cellval) {
            var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
            var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
            var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
            return date.getFullYear() + "-" + month + "-" + currentDate;
        }
    </script>
<%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>--%>
 
</head>
    <body>
        <div class="responsive-header visible-xs visible-sm">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="top-section">
                            <div class="profile-image">
                                <img src="images/profile.jpg" alt="Volton"/>
                            </div>
                            <div class="profile-content">
                                <h3 class="profile-title"><%=Uinfo.name %></h3>
                                <p class="profile-description"><%=(Uinfo.introduce == "" ? "暂无介绍..." : Uinfo.introduce )  %></p>
                              
                            </div>
                        </div>
                    </div>
                </div>
            
            </div>
        </div>
		
        <!-- SIDEBAR -->
        <div class="sidebar-menu hidden-xs hidden-sm">
            <div class="top-section">
                <div class="profile-image">
                    <img src="images/profile.jpg" alt="Volton"/>
                </div>
                <h3 class="profile-title"><%=Uinfo.name %></h3>
                <p class="profile-description"><%=(Uinfo.introduce == "" ? "暂无介绍..." : Uinfo.introduce )  %></p>
                <br />

            </div> <!-- top-section -->
            <div class="main-navigation">
                <ul class="navigation">
                  
                    <li><a href="#myworks" onclick="displaywork()"><i class="fa fa-link"></i>我的作品</a></li>
                    <li><a href="#newmycookbook" onclick="displaycookbook()"><i class="fa fa-link"></i>我的菜谱</a></li>
                    <li><a href="#mystrategy" onclick="displaystrategy()"><i class="fa fa-link"></i>我的攻略</a></li>
                    <li><a href="#cookmenu" onclick="displaycookmenu()"><i class="fa fa-link"></i>我的菜单</a></li>
                    <li><a href="#mycollect" onclick="displaycollection()"><i class="fa fa-link"></i>我的收藏</a></li>
                    <li><a href="#myconcern" onclick="displayfocus()"><i class="fa fa-link"></i>关注的人</a></li>
                    <li><a href="#myboard" onclick="displaycomment()"><i class="fa fa-link"></i>留言板</a></li>
                </ul>
            </div> <!-- .main-navigation -->
            
        </div> <!-- .sidebar-menu -->
        
        	
        <div class="banner-bg" id="top">
            <div class="banner-overlay"></div>
            <div class="welcome-text">
                <h2>欢迎来到我的主页 | <%=Uinfo.name %></h2>
                <h5><%=(Uinfo.introduce == "" ? "暂无介绍..." : Uinfo.introduce )  %></h5>
            </div>
            <br />
        </div>

        <!-- MAIN CONTENT -->
        <div class="main-content">
            <div class="fluid-container">

                <div class="content-wrapper">
                    <!---myworks---->
                    <!-- PROJECTS -->
                    <form id="works" runat="server">

                    
                          <div class="page-section" id="myworks" >
                    <div class="row">
                        <div class="col-md-12">             
                            <div class="comments-top">
                           <h3>MyWorks</h3>
                                </div>
                            <div id="workscontent"></div>
                            <div class="page" id="workspagebar"></div>
                            <div>
                                <br />

                                    <input type="button" id="addMyWork" class="btn btn-1 btn-primary" value ="添加个人作品"/>
                                </div>
                        </div>
                        <input type="button" onclick="loadCookBookList(1)" value ="测试" />
                    </div>
                    
                    </div>
                    <!---myworks-end--->

                         <!----newmycookbook----->    
                         <div class="page-section" id="newmycookbook" >
                   <div class="row">
                     <div class="col-md-12">             
                         <div class="comments-top">
                           <h3>MyCookBook</h3>
                                </div>
                     </div>
                  </div>
                        <div class="row projects-holder" id="cookbookcontent"></div>
                             <div class="page" id="cookbookpagebar"></div>
                                <div>
                                     <input type="button" id="managecookbook" onclick="ManageCookBook()" class="btn btn-1 btn-primary" value ="管理个人菜谱"/>
                                 
                                </div>
                     


                 </div>
                         <!----endnewmycookbook-----> 
                         <!----managecookbook-----> 
                        <div class="page-section" id="managecbook">

                             <div class="comments-top">
                           <h3>CookBook</h3>
                                </div>
                      <div class="bann-strip">
	                    <div class="container">
		                    <div class="bann-strip-main">
                                <center>
                                    <table id="CookBooklist" class="table">
                                        <tr class="success"><th>菜谱名</th><th>菜谱添加时间</th><th>详情</th><th>编辑</th><th>删除</th></tr>
                    
                                    </table>
                                    <div id="cbookpagebar" class ="page">

                                    </div>
                                </center>
                            </div>
                            <input type="button" class="btn btn-1 btn-warning" onclick="displaycookbook()" value ="返回我的菜谱"/>
                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                               <input type="button" id="addCookBook" class="btn btn-1 btn-primary" value ="添加个人菜谱"/>
	                    </div>

                    </div>

                        </div>
                         <!----endmanagecookbook----->       

                 
                        </form>
                    

                      <!----mystrategy------->
                     <div class="page-section" id="mystrategy" >
                                <div class="comments-top">
                           <h3>MyStrategy</h3>
                                </div>
                      <div class="bann-strip">
	                    <div class="container">
		                    <div class="bann-strip-main">
                                <center>
                                    <table id="Strategylist" class="table">
                                        <tr class="success"><th>攻略名</th><th>作者</th><th>攻略添加时间</th><th>详情</th><th>编辑</th><th>删除</th></tr>
                    
                                    </table>
                                    <div id="mspagebar" class ="page">

                                    </div>
                                </center>
                            </div>
	                    </div>
                    </div>
                     <input type="button"   onclick="window.open('showpage/addstrategy.aspx')"  id="addStrategy" class="btn btn-1 btn-primary" value ="添加攻略"/>
                    </div>
                    <!----endmystrategy------->

                    <!-- cookmenu -->
                    <div class="page-section" id="cookmenu">
                    <div class="row">
                        <div class="col-md-12">
                          
                          
                            <div id="menucontent" >
                                <div id ="showmenu">

                            </div>
                                <div id="menupagebar" class="page">
                            </div>
                                <input type="button"   onclick="window.open('showpage/addcookmenu.aspx')"  id="addcookmenu" class="btn btn-1 btn-primary" value ="添加个人菜单"/>
                          </div>
                              
                        </div>
                    </div>
                         
                    </div>
                    <!-- endcookmenu -->

                    <!-- mycollect -->
                    <div class="page-section" id="mycollect">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="comments-top">
                           <h3>MyCollection</h3>
                                </div>
                            <p></p>
                        </div>
                    </div>
                    <div class="row projects-holder" id="collectcontent"></div>
                    </div> 
                    <!-- endmycollect -->
                    <!----mycookbooklist------->
                      <div class="page-section" id="cookbooklist">

                             <div class="comments-top">
                           <h3>CookBookList</h3>
                                </div>
                      <div class="bann-strip">
	                    <div class="container">
		                    <div class="bann-strip-main">
                                <center>
                          <table  class="table" id="showmenulist">
                             
                          </table>
                                    <div class="page" id="menulistpagebar"></div>
                                </center>
                            </div>
	                    </div>

                      </div>

                      </div>

                    <!----endmycookbooklist------->
                     <!----myconcern------->
                     <div class="page-section" id="myconcern" >
                     <div id="relationship" class="simple-box">
                      <div class="content">
                        <div class="tabs clearfix">
                        <a class="on">我的关注</a>
                        </div>
                              <div class="tags clearfix">
        					                <span class="label-text">全部</span>
                              </div>
                        
                                    <div class="list row" id="focuscontent">
              
                                    </div>
                                    <div class="page" id="foucuspagebar"></div>
                                  </div>
                                </div>
                     </div>
                    <!----endmyconcern------->

                     <!----myboard------->
                     <div class="page-section" id="myboard" >
                     <center><h4 style="font-size:3px;color : gray">留言板</h4></center>
                      <div class="bann-strip">
	                    <div class="container">			
					<div class="comments-top" id="commentcontent" >
						
    				</div>
                    <div id="commentpagebar" class="page"></div>
    				<div class="comment-bottom">
    					<h3>Leave a Comment</h3>
    					<form id="lvcomment">	
						
    				</div>
				</div>	
	                    </div>
                    </div>
                    
                    </div>
                        <!----endmyboard------->


              
        

        <script src="js/vendor/jquery-1.10.2.min.js"></script>
        <script src="js/min/plugins.min.js"></script>
        <script src="js/min/main.min.js"></script>

    </body>
</html>