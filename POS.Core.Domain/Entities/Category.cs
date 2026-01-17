namespace POS.Core.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal ITBIS { get; set; }

        private readonly List<Product> Products => _products.AsReadOnly();

        private  Category (){}

        private Category(string  Name, decimal itbis){

            if(string.IsNullOrWhiteSpace(name)){
                throw new BusinessRuleException("El nombre de categoria es obligatorio");
            }   

            if(name.length < 2 || name.Length >100){
                throw new BusinessRuleExeption("El nombre debe tener entre 2 y 100 caracteres.");
            }

            if(itbis < 0 || itbis > 1){
                throw new BusinessRuleExeption("El ITBIS debe estar entre 0% y 100%");
            }

            Name = name.Trim();
            ITBIS = itbis
        }

        public static Category Create(string name, decimal itbis){
            return new Category(name, itbis);
        }

        public void changeName(string newName){
            if(string.IsNullOrWhiteSpace(newName)){
                throw new BusinessRuleException("El nombre de la categoria es obligatorio");
            }

            if(newName.length< 2 || newName.length > 10){
                throw new BusinessRuleException("El nombre debe tener entre 2 y 100 caracteres maximo")
            }

            Name = newName.trim();
        }

        public void chageItbis(decimal newItbis){
            if(newItbis < 0 || newItbis > 1){
                throw new BusinessRuleException("El ITBIS debe ser mayor a 0% y menor a 100%");
            }
            ITBIS = newItbis;
        }

         
    }
}
