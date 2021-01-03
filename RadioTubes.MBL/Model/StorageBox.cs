using System;

namespace RadioTubes.MBL.Model
{
    class StorageBox
    {
        public StorageBox()
        {
        }

        public StorageBox(int id, string storageBoxName)
        {
            Id = id;
            StorageBoxName = storageBoxName;
        }

        public int Id { get; set; }
        public string StorageBoxName { get; set; }
    }
}
