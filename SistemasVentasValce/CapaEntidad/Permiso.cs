namespace CapaEntidad
{
    public class Permiso
    {
        public int idPermiso { get; set; }
        public Rol idRol { get; set; }
        public string nombreMenu { get; set; }
        public string fechaCreacion { get; set; }

    }
}
