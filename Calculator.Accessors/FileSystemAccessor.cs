using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Calculator.Accessors
{
    public class FileSystemAccessor : AccessorBase, IStorageAccessor
    {
        public StorageData LoadStorageData(StorageData storageData)
        {
            var text = File.ReadAllText(GetFileName(storageData.InstanceId));

            return new StorageData()
            {
                InstanceId = storageData.InstanceId,
                Value = double.Parse(text, CultureInfo.CreateSpecificCulture("en-US"))
            };
        }

        public bool ClearStorageData(StorageData storageData)
        {
            var fileName = GetFileName(storageData.InstanceId);

            if (File.Exists(fileName))
                File.Delete(fileName);

            return true;
        }

        public bool SetStorageData(StorageData storageData)
        {
            var fileName = GetFileName(storageData.InstanceId);

            var resultStr = storageData.Value.ToString("E", CultureInfo.CreateSpecificCulture("en-US"));

            File.WriteAllText(fileName, resultStr);

            return true;
        }

        private static string GetFileName(Guid instanceId)
        {
            return $@".\calcstorage_{instanceId}.txt";
        }


    }
}
