using Csla;
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
        public static readonly PropertyInfo<string> DescProperty = RegisterProperty<string>(c => c.Desc);
        public string Desc
        {
            get { return GetProperty(DescProperty);}
            private set { LoadProperty(DescProperty, value); }
        }
        public static readonly PropertyInfo<string> CSSProperty = RegisterProperty<string>(c => c.CSS);
        public string CSS
        {
            get { return GetProperty(CSSProperty); }
            private set { LoadProperty(CSSProperty, value); }
        }
        [Fetch]
        private void Fetch(int id, [Inject] IOnlineStylingPropertyDal styleDal, [Inject]IDataPortal<COnlineStylingPropertyRO> dataPortal)
        {
            var style = styleDal.Fetch(id);
            Id = style.Id;
            Desc = style.Description;
            CSS = style.CSSProp;
        }
        [FetchChild]
        private void FetchChild(DOnlineStylingPropertyDto dto)
        {
            Id = dto.Id;
            Desc = dto.Description;
            CSS = dto.CSSProp;
        }
    }
}
