using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HomeworkApp.Model.ViewModels.Clothes;


namespace HomeworkApp.Parser
{
    public class Parser
    {
        public List<CreateClothesViewModel> Parse()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://www.lamoda.by/c/4152/default-men/?is_new=1&sitelink=topmenuM&l=1");
            var nodes = doc.DocumentNode.SelectNodes(".//div[contains(@class, 'x-product-card__card')]");
            List<CreateClothesViewModel> result = new List<CreateClothesViewModel>();
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var brand = node.SelectSingleNode(".//div[contains(@class, 'x-product-card-description__brand-name')]").InnerText;
                    var description = node.SelectSingleNode(".//div[contains(@class, 'x-product-card-description__product-name')]").InnerText;
                    result.Add(new CreateClothesViewModel { Brand = brand, Description = description });
                }
            }
            return result;
        }


    }
}
