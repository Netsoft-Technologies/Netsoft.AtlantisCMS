using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.DalEfCore
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;
        public DbContext (IConfiguration configuration) 
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DbSet<OnlineCompStylingProp_Entity> _OnlineComponent_StylingProperties { get; set; }
        public DbSet<OnlineComp_Entity> _OnlineComponents {  get; set; }
        public DbSet<OnlinePageComponents_Entity> _OnlinePage_Components { get; set; }
        public DbSet<OnlinePages_Entity> _OnlinePages { get; set; }
        public DbSet<OnlineSetting_Entity> _OnlineSettings { get; set; }
        public DbSet<OnlineStrings_Entity> _OnlineStrings { get; set; }
        public DbSet<OnlineStylingProp_Entity> _OnlineStylingProperties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlServer(_connectionString);
    }

    public class OnlineCompStylingProp_Entity
    {
        [Key]
        public int StylingPropertyId { get; set; }
        public int ComponentId { get; set; }
        public string Value { get; set; }
        public string CSSVariable { get; set; }
    }
    public class OnlineComp_Entity
    {
        [Key]
        public int CompId { get; set; }
        public string Description { get; set; }
        public string HTMLClassName { get; set; }
        public string HTMLElementId { get; set; }
        public int? StringContentId { get; set; }
        public int? StylingGroupId { get; set; }
    }
    public class OnlinePages_Entity
    {
        [Key]
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public int? PageOrder { get; set; }
    }
    public class OnlinePageComponents_Entity
    { 
        [Key]
        public int ComponentId { get; set; }
        public int ParentPageId { get; set; }
        public string? ParentPageTitle { get; set; }        
        public string? ComponentDesc { get; set; }
        public string? ComponentHTMLClassName { get; set; }
        public string? ComponentHTMLElementID { get; set; }
    }
    public class OnlineStrings_Entity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int? MessageId { get; set; }
        public string Message { get; set; }
        public byte? MessageType { get; set; }
    }
    public class OnlineSetting_Entity
    {
        [Key]
        public int PropertyId { get; set; }
        public bool? AcceptCustomerSignIn { get; set; }
        public bool? AcceptPMSSignIn { get; set; }
        public bool? AcceptGoogleSignIn { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string GoogleLink { get; set; }
        public string TwitterLink { get; set; }
        public bool? AcceptTreatments { get; set; }
        public bool? AcceptPackages { get; set; }
        public bool? AcceptMemberships { get; set; }
        public bool? AcceptCosmetics { get; set; }
        public bool? SendConfirmationEmail { get; set; }
        public int? ConfirmationEmailTemplateId { get; set; }
        public bool? SendInfoEmail { get; set; }
        public string SendInfoEmailList { get; set; }
        public bool? ValidPaymentCreditCard { get; set; }
        public int? CreditCardPaymentTypeId { get; set; }
        public bool? ValidPaymentPayPal { get; set; }
        public int? PayPalPaymentTypeId { get; set; }
        public bool? ValidPaymentPayOnDay { get; set; }
        public bool? ValidPaymentViva { get; set; }
        public int? VivaPaymentTypeId { get; set; }
        public bool? InvoiceIssue { get; set; }
        public bool? CreditCreate { get; set; }
        public bool? SendInvoiceEmail { get; set; }
        public int? InvoiceEmailTemplateId { get; set; }
        public bool? SendEnquiryEmail { get; set; }
        public int? EnquiryEmailTemplateId { get; set; }
        public string GoogleAnalyticsGtag1 { get; set; }
        public string GoogleAnalyticsGtag2 { get; set; }
        public string PaymentMerchantId { get; set; }
        public string PaymentSecretCode { get; set; }
        public string PaymentConfirmUrl { get; set; }
        public string PaymentCancelUrl { get; set; }
        public string PaymentGatewayUrl { get; set; }
        public bool? SendCancellationEmail { get; set; }
        public int? CancellationEmailTemplateId { get; set; }
        public bool? SendCancellationInfoEmail { get; set; }
        public string CancellationInfoEmailList { get; set; }
        public bool? SendRescheduleEmail { get; set; }
        public int? RescheduleEmailTemplateId { get; set; }
        public bool? SendRescheduleInfoEmail { get; set; }
        public string RescheduleInfoEmailList { get; set; }
        public int? HTMLPagesStylingId { get; set; }
    }
    public class OnlineStylingProp_Entity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string CSSProp { get; set; }
    }
}
