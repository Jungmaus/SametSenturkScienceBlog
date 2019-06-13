using SametSenturkScienceBlog.Data;
using SametSenturkScienceBlog.Model.Entities;
using SametSenturkScienceBlog.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SametSenturkScienceBlog.Business.OperationLibrary.DB
{

    public static class UserOperations
    {
        private static ValidationContext _validationContext;
        private static List<ValidationResult> _validationResults;

        private static ValidationContext GetValidationContext()
        {
            lock (_validationContext)
            {
                if (_validationContext == null)
                    _validationContext = new ValidationContext(new UserEntity(), serviceProvider: null, items: null);
            }

            return _validationContext;
        }

        private static bool ValidateEntity(UserEntity entity)
        {
            _validationContext = GetValidationContext();

            bool isEntityValid = Validator.TryValidateObject(entity, _validationContext, _validationResults);

            if (!isEntityValid)
            {
                string ex = "Something went wrong when validate entity. Validation Results => ";
                foreach (var result in _validationResults)
                {
                    ex += "/ Member Name => " + result.MemberNames + " - Error Message => " + result.ErrorMessage + " /";
                }

                throw new ValidationException(ex);
            }

            return isEntityValid;
        }

        private static void InsertToDatabase(UserEntity entity)
        {
            string query = "INSERT INTO User (";
            PropertyInfo[] propertyInfo = entity.GetType().GetProperties();
            KeyValuePair<string, string>[] paramsForCrud = { };
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                query += propertyInfo[i].Name;
                if (i != propertyInfo.Length - 1)
                {
                    query += ",";
                }
            }
            query += ") Values (";
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                query += "@" + propertyInfo[i].Name;
                if (i != propertyInfo.Length - 1)
                {
                    query += ",";
                }

                if (paramsForCrud.Length == 0)
                    paramsForCrud[0] = new KeyValuePair<string, string>("@" + propertyInfo[i].Name, propertyInfo[i].GetValue(entity, null).ToString());
                else
                    paramsForCrud[paramsForCrud.Length - 1] = new KeyValuePair<string, string>("@" + propertyInfo[i].Name, propertyInfo[i].GetValue(entity, null).ToString());
            }

            OperationTypeEnum operationResult = CRUD.AddOrUpdateOrDelete(query, paramsForCrud);

            if (operationResult == OperationTypeEnum.Failure)
                throw new Exception("Something went wrong.");
        }

        public static void Add(UserEntity entity)
        {
            try
            {
                bool isEntityValid = ValidateEntity(entity);
                if (isEntityValid)
                {
                    InsertToDatabase(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
