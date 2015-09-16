using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VideoDemo.Models
{
    public class VideoContext : DbContext // 1. VideoContext 繼承 DbContext 基底類別， 可以想像這是要對應成一個資料庫
    {
        public DbSet<Video> Videos { get; set; } // 2. Videos 以 DbSet<> 型別為屬性可以視為資料表 , 而 DbSet<> 內所包含的 Video 代表定義資料表內欄位名稱和型別的類別。
    }
}