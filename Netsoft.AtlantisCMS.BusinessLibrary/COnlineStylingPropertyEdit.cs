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
        public static readonly PropertyInfo<string> CSSProp = RegisterProperty<string>(c => c.CSSProperty);
        public string CSSProperty
        {
            get { return GetProperty(CSSProp); }
            set { SetProperty(CSSProp, value); }
        }
        [Create]
        [RunLocal]
        private void Create()
        {
            Description = "New Description";
            CSSProperty = "New CSS";
            BusinessRules.CheckRules();
        }
        [Fetch]
        private void Fetch(int id, [Inject]IOnlineStylingPropertyDal stylingPropertyDal, [Inject]IDataPortal<COnlineStylingPropertyRO> portal)
        {
            var item = stylingPropertyDal.Fetch(id);
            if (item == null)
            {
                return;
            }
            using (BypassPropertyChecks)
            {
                Id = item.Id;
                Description = item.Description;
                CSSProperty = item.CSSProp;
            }
        }
        [FetchChild]
        private void Fetch(DOnlineStylingPropertyDto dto, [Inject]IDataPortal<COnlineStylingPropertyRO> portal)
        {
            Id = dto.Id;
            Description = dto.Description;
            CSSProperty = dto.CSSProp;
        }
        [Insert]
        private void Insert([Inject] IOnlineStylingPropertyDal onlineStylingPropertyDal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlineStylingPropertyDto
                {
                    Id = this.Id,
                    Description = this.Description,
                    CSSProp = this.CSSProperty,
                };
                onlineStylingPropertyDal.Insert(item);
                Id = item.Id;
            }
            FieldManager.UpdateChildren(this);
        }
        [Update]
        private void Update([Inject] IOnlineStylingPropertyDal dal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlineStylingPropertyDto
                {
                    Id = this.Id,
                    Description = this.Description,
                    CSSProp = this.CSSProperty,
                };
                dal.Update(item);
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
