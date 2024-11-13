using AutoMapper;
using Csla;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netsoft.AtlantisCMS.BusinessLibrary;
using Netsoft.AtlantisCMS.Models;

namespace Netsoft.AtlantisCMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineSettingsController : ControllerBase
    {
        private readonly IDataPortal<COnlineSettingsRO> _OnlineSettingsDataPortal;
        private readonly IDataPortal<COnlineSettingEdit> _OnlineSettingsEditPortal;
        private readonly IMapper _mapper;
        public OnlineSettingsController(IDataPortal<COnlineSettingsRO> settingPortal, IDataPortal<COnlineSettingEdit> settingEditPortal, IMapper mapper)
        {
            _OnlineSettingsDataPortal = settingPortal;
            _OnlineSettingsEditPortal = settingEditPortal;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<OnlineSettingModels>> GetOnlineSettings()
        {
            var onlineSettings = await _OnlineSettingsDataPortal.FetchAsync();
            if (onlineSettings == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<List<OnlineSettingModels>>(onlineSettings);
            return Ok(res);
        }
        [HttpGet("{settingId}")]
        public async Task<ActionResult<OnlineSettingModels>> GetOnlineSetting(int settingId)
        {
            var setting = await _OnlineSettingsEditPortal.FetchAsync(settingId);
            if (setting == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<OnlineSettingModels>(setting);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<OnlineSettingModels>> Create(OnlineSettingModels newSettingReq)
        {
            if (newSettingReq == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            COnlineSettingEdit newOnlineSetting = await _OnlineSettingsEditPortal.CreateAsync();
            newOnlineSetting.AcceptCustomerSignIn = newSettingReq.AcceptCustomerSignIn;
            newOnlineSetting.AcceptPMSSignIn = newSettingReq.AcceptPMSSignIn;
            newOnlineSetting.AcceptGoogleSignIn = newSettingReq.AcceptGoogleSignIn;
            newOnlineSetting.FacebookLink = newSettingReq.FacebookLink;
            newOnlineSetting.InstagramLink = newSettingReq.InstagramLink;
            newOnlineSetting.GoogleLink = newSettingReq.GoogleLink;
            newOnlineSetting.TwitterLink = newSettingReq.TwitterLink;
            newOnlineSetting.AcceptTreatments = newSettingReq.AcceptTreatments;
            newOnlineSetting.AcceptPackages = newSettingReq.AcceptPackages;
            newOnlineSetting.AcceptMemberships = newSettingReq.AcceptMemberships;
            newOnlineSetting.AcceptCosmetics = newSettingReq.AcceptCosmetics;
            newOnlineSetting.SendConfirmationEmail = newSettingReq.SendConfirmationEmail;
            newOnlineSetting.ConfirmationEmailTemplateId = newSettingReq.ConfirmationEmailTemplateId;
            newOnlineSetting.SendInfoEmail = newSettingReq.SendInfoEmail;
            newOnlineSetting.SendInfoEmailList = newSettingReq.SendInfoEmailList;
            newOnlineSetting.ValidPaymentCreditCard = newSettingReq.ValidPaymentCreditCard;
            newOnlineSetting.CreditCardPaymentTypeId = newSettingReq.CreditCardPaymentTypeId;
            newOnlineSetting.ValidPaymentPayPal = newSettingReq.ValidPaymentPayPal;
            newOnlineSetting.PayPalPaymentTypeId = newSettingReq.PayPalPaymentTypeId;
            newOnlineSetting.ValidPaymentPayOnDay = newSettingReq.ValidPaymentPayOnDay;
            newOnlineSetting.ValidPaymentViva = newSettingReq.ValidPaymentViva;
            newOnlineSetting.VivaPaymentTypeId = newSettingReq.VivaPaymentTypeId;
            newOnlineSetting.InvoiceIssue = newSettingReq.InvoiceIssue;
            newOnlineSetting.CreditCreate = newSettingReq.CreditCreate;
            newOnlineSetting.SendInvoiceEmail = newSettingReq.SendInvoiceEmail;
            newOnlineSetting.InvoiceEmailTemplateId = newSettingReq.InvoiceEmailTemplateId;
            newOnlineSetting.SendEnquiryEmail = newSettingReq.SendEnquiryEmail;
            newOnlineSetting.EnquiryEmailTemplateId = newSettingReq.EnquiryEmailTemplateId;
            newOnlineSetting.GoogleAnalyticsGtag1 = newSettingReq.GoogleAnalyticsGtag1;
            newOnlineSetting.GoogleAnalyticsGtag2 = newSettingReq.GoogleAnalyticsGtag2;
            newOnlineSetting.PaymentMerchantId = newSettingReq.PaymentMerchantId;
            newOnlineSetting.PaymentSecretCode = newSettingReq.PaymentSecretCode;
            newOnlineSetting.PaymentConfirmUrl = newSettingReq.PaymentConfirmUrl;
            newOnlineSetting.PaymentCancelUrl = newSettingReq.PaymentCancelUrl;
            newOnlineSetting.PaymentGatewayUrl = newSettingReq.PaymentGatewayUrl;
            newOnlineSetting.SendCancellationEmail = newSettingReq.SendCancellationEmail;
            newOnlineSetting.CancellationEmailTemplateId = newSettingReq.CancellationEmailTemplateId;
            newOnlineSetting.SendCancellationInfoEmail = newSettingReq.SendCancellationInfoEmail;
            newOnlineSetting.CancellationInfoEmailList = newSettingReq.CancellationInfoEmailList;
            newOnlineSetting.SendRescheduleEmail = newSettingReq.SendRescheduleEmail;
            newOnlineSetting.RescheduleEmailTemplateId = newSettingReq.RescheduleEmailTemplateId;
            newOnlineSetting.SendRescheduleInfoEmail = newSettingReq.SendRescheduleInfoEmail;
            newOnlineSetting.RescheduleInfoEmailList = newSettingReq.RescheduleInfoEmailList;
            newOnlineSetting.HTMLPagesStylingId = newSettingReq.HTMLPagesStylingId;
            newOnlineSetting = await newOnlineSetting.SaveAsync();
            var res = _mapper.Map<OnlineSettingModels>(newOnlineSetting);
            return Ok(res);
        }
        [HttpPut("{settingId}")]
        public async Task<ActionResult<OnlineSettingModels>> EditOnlineSettings(int settingId, OnlineSettingModels editSettingReq)
        {
            if (editSettingReq == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var settingEdit = await _OnlineSettingsEditPortal.FetchAsync(settingId);
            if( settingEdit.PropertyId != settingId)
            {
                return BadRequest("Missmatch");
            }
            settingEdit.AcceptCustomerSignIn = editSettingReq.AcceptCustomerSignIn;
            settingEdit.AcceptPMSSignIn = editSettingReq.AcceptPMSSignIn;
            settingEdit.AcceptGoogleSignIn = editSettingReq.AcceptGoogleSignIn;
            settingEdit.FacebookLink = editSettingReq.FacebookLink;
            settingEdit.InstagramLink = editSettingReq.InstagramLink;
            settingEdit.GoogleLink = editSettingReq.GoogleLink;
            settingEdit.TwitterLink = editSettingReq.TwitterLink;
            settingEdit.AcceptTreatments = editSettingReq.AcceptTreatments;
            settingEdit.AcceptPackages = editSettingReq.AcceptPackages;
            settingEdit.AcceptMemberships = editSettingReq.AcceptMemberships;
            settingEdit.AcceptCosmetics = editSettingReq.AcceptCosmetics;
            settingEdit.SendConfirmationEmail = editSettingReq.SendConfirmationEmail;
            settingEdit.ConfirmationEmailTemplateId = editSettingReq.ConfirmationEmailTemplateId;
            settingEdit.SendInfoEmail = editSettingReq.SendInfoEmail;
            settingEdit.SendInfoEmailList = editSettingReq.SendInfoEmailList;
            settingEdit.ValidPaymentCreditCard = editSettingReq.ValidPaymentCreditCard;
            settingEdit.CreditCardPaymentTypeId = editSettingReq.CreditCardPaymentTypeId;
            settingEdit.ValidPaymentPayPal = editSettingReq.ValidPaymentPayPal;
            settingEdit.PayPalPaymentTypeId = editSettingReq.PayPalPaymentTypeId;
            settingEdit.ValidPaymentPayOnDay = editSettingReq.ValidPaymentPayOnDay;
            settingEdit.ValidPaymentViva = editSettingReq.ValidPaymentViva;
            settingEdit.VivaPaymentTypeId = editSettingReq.VivaPaymentTypeId;
            settingEdit.InvoiceIssue = editSettingReq.InvoiceIssue;
            settingEdit.CreditCreate = editSettingReq.CreditCreate;
            settingEdit.SendInvoiceEmail = editSettingReq.SendInvoiceEmail;
            settingEdit.InvoiceEmailTemplateId = editSettingReq.InvoiceEmailTemplateId;
            settingEdit.SendEnquiryEmail = editSettingReq.SendEnquiryEmail;
            settingEdit.EnquiryEmailTemplateId = editSettingReq.EnquiryEmailTemplateId;
            settingEdit.GoogleAnalyticsGtag1 = editSettingReq.GoogleAnalyticsGtag1;
            settingEdit.GoogleAnalyticsGtag2 = editSettingReq.GoogleAnalyticsGtag2;
            settingEdit.PaymentMerchantId = editSettingReq.PaymentMerchantId;
            settingEdit.PaymentSecretCode = editSettingReq.PaymentSecretCode;
            settingEdit.PaymentConfirmUrl = editSettingReq.PaymentConfirmUrl;
            settingEdit.PaymentCancelUrl = editSettingReq.PaymentCancelUrl;
            settingEdit.PaymentGatewayUrl = editSettingReq.PaymentGatewayUrl;
            settingEdit.SendCancellationEmail = editSettingReq.SendCancellationEmail;
            settingEdit.CancellationEmailTemplateId = editSettingReq.CancellationEmailTemplateId;
            settingEdit.SendCancellationInfoEmail = editSettingReq.SendCancellationInfoEmail;
            settingEdit.CancellationInfoEmailList = editSettingReq.CancellationInfoEmailList;
            settingEdit.SendRescheduleEmail = editSettingReq.SendRescheduleEmail;
            settingEdit.RescheduleEmailTemplateId = editSettingReq.RescheduleEmailTemplateId;
            settingEdit.SendRescheduleInfoEmail = editSettingReq.SendRescheduleInfoEmail;
            settingEdit.RescheduleInfoEmailList = editSettingReq.RescheduleInfoEmailList;
            settingEdit.HTMLPagesStylingId = editSettingReq.HTMLPagesStylingId;
            settingEdit = await settingEdit.SaveAsync();
            var res = _mapper.Map<OnlineSettingModels>(settingEdit);
            return Ok(res);
        }
        [HttpDelete("{settingId}")]
        public async Task<IActionResult> DeleteSettings (int settingId)
        {
            var settingForDeletion = await _OnlineSettingsEditPortal.FetchAsync(settingId);
            if (settingForDeletion == null || settingForDeletion.PropertyId == 0)
            {
                return NotFound($"Settings with id: {settingId} not found.");
            }
            try
            {
                await _OnlineSettingsEditPortal.DeleteAsync(settingId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting settings: {ex.Message}");
            }
        }
    }
}
