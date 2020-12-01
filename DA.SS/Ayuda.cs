namespace DA.SS
{
    public static class Ayuda
    {
        public static void Mostrar()
        {
            string commandText = Directorio.GetExecutingDirectoryName() + @"\Ayuda\DesignacionArbitralAyuda.chm";
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }
    }
}
