namespace backend.Dtos
{
    public class CustomerDto// es un objeto que se utiliza para transferir informacion de la api o entre capas
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
