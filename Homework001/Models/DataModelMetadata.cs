using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Homework001.Models
{
    [MetadataType(typeof(CustomerMetadata))]
    public partial class 客戶資料
    { 
    
    }

    public class CustomerMetadata
    {
        [Display(Name = "客戶名稱")]
        [Required(ErrorMessage = "必填")]
        [StringLength(50)]
        public string 客戶名稱 { get; set; }

        [Display(Name = "統一編號")]
        [Required(ErrorMessage = "必填")]
        [StringLength(8)]
        public string 統一編號 { get; set; }

        [Display(Name = "電話")]
        [Required(ErrorMessage = "必填")]
        [StringLength(50)]
        public string 電話 { get; set; }

        [StringLength(50)]
        public string 傳真 { get; set; }

        [StringLength(100)]
        public string 地址 { get; set; }

        [StringLength(250)]
        [EmailAddress]
        [UIHint("email")]
        public string Email { get; set; }

    }


    [MetadataType(typeof(ContractMetadata))]
    public partial class 客戶聯絡人
    {
/*
    [客戶Id]  INT            NOT NULL,
    [職稱]    NVARCHAR (50)  NOT NULL,
    [姓名]    NVARCHAR (50)  NOT NULL,
    [Email] NVARCHAR (250) NOT NULL,
    [手機]    NVARCHAR (50)  NULL,
    [電話]    NVARCHAR (50)  NULL,
*/
    }

    public class ContractMetadata
    {
        [Display(Name = "客戶Id")]
        [Required(ErrorMessage = "必填")]
        [RegularExpression(@"\d+")]
        public int 客戶Id { get; set; }

        [Display(Name = "職稱")]
        [Required(ErrorMessage = "必填")]
        [StringLength(50)]
        public string 職稱 { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "必填")]
        [StringLength(50)]
        public string 姓名 { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "必填")]
        [StringLength(250)]
        [EmailAddress]
        [UIHint("email")]
        public string Email { get; set; }

        [Display(Name = "手機")]
        [StringLength(50)]
        public string 手機 { get; set; }

        [Display(Name = "電話")]
        [StringLength(50)]
        public string 電話 { get; set; }
    }


    [MetadataType(typeof(BankInformationMetadata))]
    public partial class 客戶銀行資訊
    {
/*
    [客戶Id] INT           NOT NULL,
    [銀行名稱] NVARCHAR (50) NOT NULL,
    [銀行代碼] INT           NOT NULL,
    [分行代碼] INT           NULL,
    [帳戶名稱] NVARCHAR (50) NOT NULL,
    [帳戶號碼] NVARCHAR (20) NOT NULL,
*/
    }

    public class BankInformationMetadata
    {
        [Display(Name = "客戶Id")]
        [Required(ErrorMessage = "必填")]
        public int 客戶Id { get; set; }

        [Display(Name = "銀行名稱")]
        [Required(ErrorMessage = "必填")]
        [StringLength(50)]
        public string 銀行名稱 { get; set; }
        
        [Display(Name = "銀行代碼")]
        [Required(ErrorMessage = "必填")]
        public int 銀行代碼 { get; set; }
        
        [Display(Name = "分行代碼")]
        public Nullable<int> 分行代碼 { get; set; }
        
        [Display(Name = "帳戶名稱")]
        [Required(ErrorMessage = "必填")]
        [StringLength(50)]
        public string 帳戶名稱 { get; set; }
        
        [Display(Name = "帳戶號碼")]
        [Required(ErrorMessage = "必填")]
        [StringLength(20)]
        public string 帳戶號碼 { get; set; }

    }
}