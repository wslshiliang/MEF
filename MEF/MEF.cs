using DAL;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace WYQ.MEF
{
    public  class MEF<T> where T: IBase
    {
        [Import]
        public T call { get; set; }

        public void Compose()
        {
            try
            {
                //主程序所在目录的Cards文件夹,将生成的类程序集放入其中
                var catalog = new DirectoryCatalog("MEF");
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
