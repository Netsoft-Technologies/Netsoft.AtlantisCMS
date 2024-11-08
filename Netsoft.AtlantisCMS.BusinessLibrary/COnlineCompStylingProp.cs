using Csla;
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
        public static readonly PropertyInfo<int> StylingPropIdProperty = RegisterProperty<int>(p => p.StylingPropId);
        public int StylingPropId
        {
            get { return GetProperty(StylingPropIdProperty); }
            set { SetProperty(StylingPropIdProperty, value); }
        }
        public static readonly PropertyInfo<int> ParentCompIdProperty = RegisterProperty<int>(p => p.ParentCompId);
        public int ParentCompId
        {
            get { return GetProperty(ParentCompIdProperty); }
            set { SetProperty(ParentCompIdProperty, value); }
        }
        public static readonly PropertyInfo<string> StyleValueProperty = RegisterProperty<string>(p => p.StyleValue);
        public string StyleValue
        {
            get { return GetProperty(StyleValueProperty); }
            set { SetProperty(StyleValueProperty, value); }
        }
        [Create]
        [RunLocal]
        private void Create()
        {
            StyleValue = "New Style Value";
            BusinessRules.CheckRules();
        }
        [Fetch]
        private void Fetch(int parentCompId, int stylingPropId, [Inject] IOnlineComponentStylingPropertyDal styleDal)
        {
            var styleData = styleDal.Fetch(parentCompId, stylingPropId);
            using (BypassPropertyChecks)
            {
                StylingPropId = styleData.StylingPropId;
                ParentCompId = styleData.ParentCompId;
                StyleValue = styleData.StyleValue;
            }
        }
        [FetchChild]
        private void Fetch(DOnlineComponentStylingPropertyDto styleDto)
        {
            StylingPropId = styleDto.StylingPropId;
            ParentCompId = styleDto.ParentCompId;
            StyleValue = styleDto.StyleValue;
        }
        [Insert]
        private void Insert([Inject] IOnlineComponentStylingPropertyDal styleDal)
        {
            using (BypassPropertyChecks)
            {
                var newStyleValue = new DOnlineComponentStylingPropertyDto
                {
                    StylingPropId = StylingPropId,
                    ParentCompId = ParentCompId,
                    StyleValue = this.StyleValue,
                };
                styleDal.Insert(newStyleValue);
            }
            FieldManager.UpdateChildren(this);
        }
        [Update]
        public void Update([Inject] IOnlineComponentStylingPropertyDal styleDal)
        {
            using (BypassPropertyChecks)
            {
                var editStyleValue = new DOnlineComponentStylingPropertyDto
                {
                    StylingPropId = StylingPropId,
                    ParentCompId = ParentCompId,
                    StyleValue = this.StyleValue,
                };
                styleDal.Update(editStyleValue);
            }
        }
        [Delete]
        private void Delete(int stylePropId, [Inject] IOnlineComponentStylingPropertyDal styleDal)
        {
            styleDal.Delete(stylePropId, ParentCompId);
        }
    }
}
