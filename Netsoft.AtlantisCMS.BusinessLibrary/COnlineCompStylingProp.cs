﻿using Csla;
using Csla.Core;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.BusinessLibrary
{
    [Serializable]
    public class COnlineCompStylingProp : BusinessBase<COnlineCompStylingProp>
    {
        public static readonly PropertyInfo<int> StylingPropIdProperty = RegisterProperty<int>(p => p.StylingPropertyId);
        public int StylingPropertyId
        {
            get { return GetProperty(StylingPropIdProperty); }
            set { SetProperty(StylingPropIdProperty, value); }
        }
        public static readonly PropertyInfo<int> ParentCompIdProperty = RegisterProperty<int>(p => p.ComponentId);
        public int ComponentId
        {
            get { return GetProperty(ParentCompIdProperty); }
            set { SetProperty(ParentCompIdProperty, value); }
        }
        public static readonly PropertyInfo<string> StyleValueProperty = RegisterProperty<string>(p => p.Value);
        public string Value
        {
            get { return GetProperty(StyleValueProperty); }
            set { SetProperty(StyleValueProperty, value); }
        }

        [Create]
        [RunLocal]
        private void Create()
        {
            Value = "New Style Value";
            BusinessRules.CheckRules();
        }
        [Fetch]
        private void Fetch(int parentCompId, int stylingPropId, [Inject] IOnlineComponentStylingPropertyDal styleDal)
        {
            var styleData = styleDal.Fetch(parentCompId, stylingPropId);
            if (styleData == null) return;
            using (BypassPropertyChecks)
            {
                StylingPropertyId = styleData.StylingPropertyId;
                ComponentId = styleData.ComponentId;
                Value = styleData.Value;
            }
        }
        [FetchChild]
        private void Fetch(DOnlineComponentStylingPropertyDto styleDto)
        {
            StylingPropertyId = styleDto.StylingPropertyId;
            ComponentId = styleDto.ComponentId;
            Value = styleDto.Value;
        }
        [Insert]
        private void Insert([Inject] IOnlineComponentStylingPropertyDal styleDal)
        {
            using (BypassPropertyChecks)
            {
                var newStyleValue = new DOnlineComponentStylingPropertyDto
                {
                    StylingPropertyId = StylingPropertyId,
                    ComponentId = ComponentId,
                    Value = this.Value
                };
                styleDal.Insert(newStyleValue);
            }
            FieldManager.UpdateChildren(this);
        }
        [InsertChild]
        private void InsertChild(COnlineComponentEdit parentComp, [Inject] IOnlineComponentStylingPropertyDal styleDal)
        {
            using (BypassPropertyChecks)
            {
                var newStyleValue = new DOnlineComponentStylingPropertyDto
                {
                    StylingPropertyId = this.StylingPropertyId,
                    ComponentId = parentComp.Id,
                    Value = this.Value
                };
                styleDal.Insert(newStyleValue);
            }
            FieldManager.UpdateChildren(this);
        }
        [Update]
        private void Update([Inject] IOnlineComponentStylingPropertyDal styleDal)
        {
            using (BypassPropertyChecks)
            {
                var editStyleValue = new DOnlineComponentStylingPropertyDto
                {
                    StylingPropertyId = StylingPropertyId,
                    ComponentId = ComponentId,
                    Value = this.Value
                };
                styleDal.Update(this.ComponentId, this.StylingPropertyId, editStyleValue);
            }
        }
        [Delete]
        private void Delete(int compId, int styleId, [Inject] IOnlineComponentStylingPropertyDal styleDal)
        {
            styleDal.Delete(compId, styleId);
        }

        [DeleteSelfChild]
        private void Delete(COnlineComponentEdit parentComp, [Inject] IOnlineComponentStylingPropertyDal styleDal)
        {
            styleDal.Delete(parentComp.Id, StylingPropertyId);
        }
    }
}
