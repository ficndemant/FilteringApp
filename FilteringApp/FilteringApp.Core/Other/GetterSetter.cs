using System;
using System.Collections.Generic;
using System.Text;

namespace FilteringApp.Core.Other
{
    class GetterSetter
    {
        public int theProperty { get; set; }

        private int _value;

        public int Id
        {
            get => RetrieveId();
            set => StoreId(value);
        }

        private void StoreId(int id) { }
        private int RetrieveId() => 1;
    }
}
