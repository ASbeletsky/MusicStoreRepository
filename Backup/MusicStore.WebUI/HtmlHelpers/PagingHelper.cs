using System;
using System.Text;
using System.Web.Mvc;
using MusicStore.WebUI.Models.MusicInstruments;

namespace MusicStore.WebUI.HtmlHelpers
{
    public static class PagingHelper
    {
        //Расширяемый метод генирации HTML-разметки для набора ссылок на страницы 
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                                PagingInfo pagingInfo,
                                                Func<int, string> pageURL)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                //Создаем новый тег <a></a> для создания ссылок
                TagBuilder tag = new TagBuilder("a");
                //Добавляем к нему новый атрибут href - html ссылку
                tag.MergeAttribute("href", pageURL(i)); 
                //Устанавливаем значение тега
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    //Добавляем Css классы в список Css класов тега
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            //Возвращаем HTML-разметку
            return MvcHtmlString.Create(result.ToString());
        }

    }
}
