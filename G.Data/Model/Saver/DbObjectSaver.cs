﻿using G.Data.Definition;
using G.Data.Model.Composer;
using G.Data.Model.Handler;
using G.Data.SqlEntry;

namespace G.Data.Model.Saver
{
    class DbObjectSaver : SimpleObjectSaver
    {
        public DbObjectSaver(ObjectInfo info, QueryComposer composer, DataProvider provider, IDbObjectHandler handler)
            : base(info, composer, provider, handler)
        {
        }

        public override void Save(IDbObject obj)
        {
            var key = Info.KeyMembers[0];
            this.InnerSave(key.UnsavedValue.Equals(Handler.GetKeyValue(obj)), obj);
        }

        private void InnerSave(bool isInsert, IDbObject obj)
        {
            if (isInsert)
            {
                Insert(obj);
            }
            else
            {
                Update(obj);
            }
        }

        public override object Insert(IDbObject obj)
        {
            var sb = Composer.GetInsertStatementBuilder(obj);
            var key = Provider.Dialect.ExecuteInsert(sb, Info, Provider);
            Handler.SetKeyValue(obj, key);
            return key;
        }
    }
}
