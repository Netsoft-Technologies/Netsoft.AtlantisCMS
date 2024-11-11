using Csla;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static readonly PropertyInfo<string> DescProperty = RegisterProperty<string>(c => c.Desc);
        public string Desc
        {
            get { return GetProperty(DescProperty); }
            set { SetProperty(DescProperty, value); }
        }
        public static readonly PropertyInfo<string> CSSProperty = RegisterProperty<string>(c => c.CSS);
        public string CSS
        {
            get { return GetProperty(CSSProperty); }
            set { SetProperty(CSSProperty, value); }
        }
        [Create]
        [RunLocal]
        private void Create()
        {
            Desc = "New Description";
            CSS = "New CSS";
            BusinessRules.CheckRules();
        }
        [Fetch]
        private void Fetch(int id, [Inject]IOnlineStylingPropertyDal stylingPropertyDal, [Inject]IDataPortal<COnlineStylingPropertyRO> portal)
        {
            var item = stylingPropertyDal.Fetch(id);
            using (BypassPropertyChecks)
            {
                Id = item.Id;
                Desc = item.Description;
                CSS = item.CSSProp;
            }
        }
        [FetchChild]
        private void Fetch(DOnlineStylingPropertyDto dto, [Inject]IDataPortal<COnlineStylingPropertyRO> portal)
        {
            Id = dto.Id;
            Desc = dto.Description;
            CSS = dto.CSSProp;
        }
        [Insert]
        private void Insert([Inject] IOnlineStylingPropertyDal onlineStylingPropertyDal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlineStylingPropertyDto
                {
                    Id = this.Id,
                    Description = this.Desc,
                    CSSProp = this.CSS,
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
                    Description = this.Desc,
                    CSSProp = this.CSS,
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
