using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//1.加上修飾用語

namespace VideoDemo.Models
{
    public class Video
    {
        //1. 字串型別的 Id 屬性除了用來當作主鍵（ Primary Key ） 值之外， 也用來代表一部 YouTube 影片 的影片 代碼。
        [Display(Name = "影片代碼")] // 欄位抬頭所要顯示的文字
        [Required(ErrorMessage = "{0}不可空白")] // 1.2 加上限制條件
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0}必須是{1}個字元")]
        [UIHint("Video")] //1.3 介面是用哪一個樣版（ Template）屬性的上方加個類似 [UIHint("Video")] 的修飾詞， 其目的是為了指示該欄位在顯示和編輯時， 該使用哪一個版型來表示 Views\Shared\DisplayTemplates\Video.cshtml
        public string Id { get; set; } //1.1 定義模型屬性


        //2. 字串型別的 Title 屬性用來說明影片 的主題。
        [Display(Name = "影片標題")]
        [Required(ErrorMessage = "{0}不可空白")]
        [MaxLength(20)]
        public string Title { get; set; }

        //3. 日期時間型別的 StartDate 屬性用來設定影片 開始播放的日期。
        [UIHint("Date")] //  顯示\Views\Shared\DisplayTemplates\Date.cshtml  , 編輯\Views\Shared\EditorTemplates\Date.cshtml
        [Display(Name = "開始日期")]
        public DateTime StartDate { get; set; }

        //4. 日期時間型別的 EndDate 屬性用來設定影片 結束播放的日期。
        [UIHint("Date")]
        [Display(Name = "結束日期")]
        public DateTime EndDate { get; set; }

    }
}