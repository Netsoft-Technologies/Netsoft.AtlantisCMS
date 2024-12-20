﻿using Csla;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.BusinessLibrary
{
    [Serializable]
    public class COnlineStringRO : ReadOnlyBase<COnlineStringRO>
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            private set { LoadProperty(IdProperty, value); }
        }
        public static readonly PropertyInfo<string> TitleProperty = RegisterProperty<string>(c => c.Title);
        public string Title
        {
            get { return GetProperty(TitleProperty);}
            private set { LoadProperty(TitleProperty, value); }
        }
        public static readonly PropertyInfo<int?> MessageIdProperty = RegisterProperty<int?>(c => c.MessageId);
        public int? MessageId
        {
            get { return GetProperty(MessageIdProperty); }
            private set { LoadProperty(MessageIdProperty, value); }
        }
        public static readonly PropertyInfo<string> MessageProperty = RegisterProperty<string>(c => c.Message);
        public string Message
        {
            get { return GetProperty(MessageProperty); }
            private set { LoadProperty(MessageProperty, value); } 
        }
        public static readonly PropertyInfo<byte?> MessageTypeProperty = RegisterProperty<byte?>(c => c.MessageType);
        public byte? MessageType
        {
            get { return GetProperty(MessageTypeProperty); }
            private set { LoadProperty(MessageTypeProperty, value); }
        }
        [Fetch]
        private void Fetch(int stringId, [Inject] IOnlineStringDal stringDal, [Inject] IDataPortal<COnlineStringRO> propPortal)
        {
            var settingDto = stringDal.Fetch(stringId);
            Id = settingDto.Id;
            Title = settingDto.Title;
            MessageId = settingDto.MessageId;
            Message = settingDto.Message;
            MessageType = settingDto.MessageType;
        }

        [FetchChild]
        private void FetchChild(DOnlineStringDto stringDto)
        {
            Id = stringDto.Id;
            Title = stringDto.Title;
            MessageId = stringDto.MessageId;
            Message = stringDto.Message;
            MessageType = stringDto.MessageType;
        }
    }
}
