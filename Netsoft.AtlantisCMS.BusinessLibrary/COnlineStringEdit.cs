using Csla;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.BusinessLibrary
{
    [Serializable]
    public class COnlineStringEdit : BusinessBase<COnlineStringEdit>
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }
        public static readonly PropertyInfo<string> TitleProperty = RegisterProperty<string>(c => c.Title);
        public string Title
        {
            get { return GetProperty(TitleProperty); }
            set { SetProperty(TitleProperty, value); }
        }
        public static readonly PropertyInfo<int?> MessageIdProperty = RegisterProperty<int?>(c => c.MessageId);
        public int? MessageId
        {
            get { return GetProperty(MessageIdProperty); }
            set { SetProperty(MessageIdProperty, value); }
        }
        public static readonly PropertyInfo<string> MessageProperty = RegisterProperty<string>(c => c.Message);
        public string Message
        {
            get { return GetProperty(MessageProperty); }
            set { SetProperty(MessageProperty, value); }
        }
        public static readonly PropertyInfo<byte?> MessageTypeProperty = RegisterProperty<byte?>(c => c.MessageType);
        public byte? MessageType
        {
            get { return GetProperty(MessageTypeProperty); }
            set { SetProperty(MessageTypeProperty, value); }
        }

        [Create]
        [RunLocal]
        private void Create()
        {
            Message = "New Message";
            BusinessRules.CheckRules();
        }
        [Fetch]
        private void Fetch(int id, [Inject]IOnlineStringDal onlineStringDal)
        {
            var data = onlineStringDal.Fetch(id);
            if (data == null)
            {
                return;
            }
            using (BypassPropertyChecks)
            {
                Id = data.Id;
                Title = data.Title;
                MessageId = data.MessageId;
                Message = data.Message;
                MessageType = data.MessageType;
            }
        }
        [FetchChild]
        private void Fetch(DOnlineStringDto dto)
        {
            Id = dto.Id;
            Title = dto.Title;
            MessageId = dto.MessageId;
            Message = dto.Message;
            MessageType = dto.MessageType;
        }
        [Insert]
        private void Insert([Inject] IOnlineStringDal dal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlineStringDto
                {
                    Id = this.Id,
                    Title = this.Title,
                    MessageId = this.MessageId,
                    Message = this.Message,
                    MessageType = this.MessageType
                };
                dal.Insert(item);
                Id = item.Id;
            }
            FieldManager.UpdateChildren(this);
        }
        [Update]
        private void Update([Inject] IOnlineStringDal dal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlineStringDto
                {
                    Id = this.Id,
                    Title = this.Title,
                    MessageId = this.MessageId,
                    Message = this.Message,
                    MessageType = this.MessageType
                };
                dal.Update(item);
            }
            FieldManager.UpdateChildren(this.Id);
        }
        [Delete]
        private void Delete(int id, [Inject] IOnlineStringDal dal)
        {
            dal.Delete(id);
        }
    }
}
