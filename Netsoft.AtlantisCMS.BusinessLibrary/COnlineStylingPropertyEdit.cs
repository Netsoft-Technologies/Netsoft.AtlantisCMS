using Csla;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.BusinessLibrary
{
    [Serializable]
    public class COnlineStylingPropertyEdit : BusinessBase<COnlineStylingPropertyEdit>
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }
        public static readonly PropertyInfo<string> DescProp = RegisterProperty<string>(c => c.Description);
        public string Description
        {
            get { return GetProperty(DescProp); }
            set { SetProperty(DescProp, value); }
        }
        public static readonly PropertyInfo<string> CSSProperty = RegisterProperty<string>(c => c.CSSProp);
        public string CSSProp
        {
            get { return GetProperty(CSSProperty); }
            set { SetProperty(CSSProperty, value); }
        }
        [Create]
        [RunLocal]
        private void Create()
        {
            Description = "New Description";
            CSSProp = "New CSS";
            BusinessRules.CheckRules();
        }

        //most likely not needed to inject DataPortal
        [Fetch]
        private void Fetch(int styleId, [Inject]IOnlineStylingPropertyDal stylingPropertyDal, [Inject]IDataPortal<COnlineStylingPropertyRO> portal) 
        {
            var settingDto = stylingPropertyDal.Fetch(styleId);
            if (settingDto == null)
            {
                return;
            }
            using (BypassPropertyChecks)
            {
                Id = settingDto.Id;
                Description = settingDto.Description;
                CSSProp = settingDto.CSSProp;
            }
        }
        [FetchChild]
        private void Fetch(DOnlineStylingPropertyDto dto, [Inject]IDataPortal<COnlineStylingPropertyRO> portal)
        {
            Id = dto.Id;
            Description = dto.Description;
            CSSProp = dto.CSSProp;
        }
        [Insert]
        private void Insert([Inject] IOnlineStylingPropertyDal onlineStylingPropertyDal)
        {
            using (BypassPropertyChecks)
            {
                var settingDto = new DOnlineStylingPropertyDto
                {
                    Id = this.Id,
                    Description = this.Description,
                    CSSProp = this.CSSProp,
                };
                onlineStylingPropertyDal.Insert(settingDto);
                Id = settingDto.Id;
            }
            FieldManager.UpdateChildren(this);
        }
        [Update]
        private void Update([Inject] IOnlineStylingPropertyDal dal)
        {
            using (BypassPropertyChecks)
            {
                var settingDto = new DOnlineStylingPropertyDto
                {
                    Id = this.Id,
                    Description = this.Description,
                    CSSProp = this.CSSProp,
                };
                dal.Update(settingDto);
            }
            FieldManager.UpdateChildren(this.Id);
        }
        [Delete]
        private void Delete(int id, [Inject]IOnlineStylingPropertyDal dal)
        {
            dal.Delete(id);
        }
    }
}
