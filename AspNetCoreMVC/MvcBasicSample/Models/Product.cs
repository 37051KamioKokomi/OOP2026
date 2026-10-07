using System.ComponentModel.DataAnnotations;
namespace MvcBasicSample.Models;
// Products テーブルの1 行に対応する商品
public class Product {
    public int Id { get; set; } // 主キー
                                // 商品名を必須の項目として扱う
    [Required]
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; } // 円単位
}