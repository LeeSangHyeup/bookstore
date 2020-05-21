using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics; 

public partial class main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
                Debug.Assert(dbHandler != null);

                Book humanBook = dbHandler.inquaryRandomBook("인문");
                humanImage.ImageUrl = "~/view/bookImages/" + humanBook.getbookNumber() + ".jpg";
                humanLabel.Text = cutArticle(humanBook.getIntroduce()) + "...";

                Book novelBook = dbHandler.inquaryRandomBook("소설");
                novelImgae.ImageUrl = "~/view/bookImages/" + novelBook.getbookNumber() + ".jpg";
                novelLabel.Text = cutArticle(novelBook.getIntroduce()) + "...";

                Book selfDevelopeBook = dbHandler.inquaryRandomBook("자기개발");
                selfDevelopImage.ImageUrl = "~/view/bookImages/" + selfDevelopeBook.getbookNumber() + ".jpg";
                selfDevelopeLabel.Text = cutArticle(selfDevelopeBook.getIntroduce()) + "...";

                Book youthBook = dbHandler.inquaryRandomBook("청소년");
                youthImage.ImageUrl = "~/view/bookImages/" + youthBook.getbookNumber() + ".jpg";
                youthLabel.Text = cutArticle(youthBook.getIntroduce()) + "...";

                Book foreignBook = dbHandler.inquaryRandomBook("해외");
                foreignImage.ImageUrl = "~/view/bookImages/" + foreignBook.getbookNumber() + ".jpg";
                foreignLabel.Text = cutArticle(foreignBook.getIntroduce()) + "...";
            }
            catch { /*ignore*/}
        }
    }
    private string cutArticle(string article)
    {
        if (article.Length > 25) article = article.Substring(0, 30);

        return article;
    }
}