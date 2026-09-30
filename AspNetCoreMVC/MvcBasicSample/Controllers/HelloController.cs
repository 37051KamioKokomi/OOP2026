using Microsoft.AspNetCore.Mvc; //ControllerとIActionResultを使用
using MvcBasicSample.Models;　　//Productを使用

namespace MvcBasicSample.Controllers;

//URLのHelloに対応する要求を受け取るController
public class HelloController : Controller{

    // ../Hello/Indexで呼び出されるAction
    public IActionResult Index() {

        //Productを複数まとめる一覧を作る
        var products = new List<Product> {
            new Product {
                Name = "ハンバーガー",
                Price = 500
            },
            new Product {
                Name = "紅茶",
                Price = 450
            }
        };
       
        return View(products);

        //Viewを使用せず文字列をHTTPの応答として返す
        //return Content("初めてのASP.NET Core");
    }

}

