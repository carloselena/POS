using POS.Core.Domain.Exceptions;
using POS.Core.Domain.Exceptions.BusinessRuleException;

namespace POS.Core.Domain.Entities
{
    

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal ITBIS { get; set; }

        private readonly List<Product> _products = new List<Product>();


        private  Category (){}

        private Category(string  name, decimal itbis){

            if(string.IsNullOrWhiteSpace(name)){
                throw new BusinessRuleException("El nombre de categoria es obligatorio");
            }   

            if(name.Length < 2 || name.Length >10){
                throw new BusinessRuleException("El nombre debe tener entre 2 y 10 caracteres.");
            }

            if(itbis < 0 || itbis > 1){
                throw new BusinessRuleException("El ITBIS debe estar entre 0% y 100%");
            }

            Name = name.Trim();
            ITBIS = itbis;
        }

        public static Category Create(string name, decimal itbis){
            return new Category(name, itbis);
        }

        public void ChangeName(string newName){
            if(string.IsNullOrWhiteSpace(newName)){
                throw new BusinessRuleException("El nombre de la categoria es obligatorio");
            }

            if(newName.Length< 2 || newName.Length > 10){
                throw new BusinessRuleException("El nombre debe tener entre 2 y 100 caracteres maximo");
            }

            Name = newName.Trim();
        }

        public void ChangeItbis(decimal newItbis){
            if(newItbis < 0 || newItbis > 1){
                throw new BusinessRuleException("El ITBIS debe ser mayor a 0% y menor a 100%");
            }
            ITBIS = newItbis;
        }

         
    }
}



