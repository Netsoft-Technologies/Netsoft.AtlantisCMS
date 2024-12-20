﻿using Csla;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.BusinessLibrary
{
    [Serializable]
    public class COnlineStylingPropertyRO : ReadOnlyBase<COnlineStylingPropertyRO>
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            private set { LoadProperty(IdProperty, value); }
        }
        public static readonly PropertyInfo<string> DescProperty = RegisterProperty<string>(c => c.Description);
        public string Description
        {
            get { return GetProperty(DescProperty);}
            private set { LoadProperty(DescProperty, value); }
        }
        public static readonly PropertyInfo<string> CSSProperty = RegisterProperty<string>(c => c.CSSProp);
        public string CSSProp
        {
            get { return GetProperty(CSSProperty); }
            private set { LoadProperty(CSSProperty, value); }
        }

        //most likely not needed to inject DataPortal
        [Fetch]
        private void Fetch(int styleId, [Inject] IOnlineStylingPropertyDal styleDal, [Inject]IDataPortal<COnlineStylingPropertyRO> dataPortal)
        {
            var style = styleDal.Fetch(styleId);
            Id = style.Id;
            Description = style.Description;
            CSSProp = style.CSSProp;
        }
        [FetchChild]
        private void FetchChild(DOnlineStylingPropertyDto dto)
        {
            Id = dto.Id;
            Description = dto.Description;
            CSSProp = dto.CSSProp;
        }
    }
}
