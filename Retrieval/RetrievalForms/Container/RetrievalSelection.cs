using System;

namespace Retrieval.RetrievalForms.Container
{
    public class RetrievalSelection
    {
        private static RetrievalSelection options = null;
        private static readonly object syncRoot = new object();
        private static RetrievalSelection Options
        {
            get
            {
                if (options == null)
                {
                    lock (syncRoot)
                    {
                        if (options == null)
                        {
                            options = new RetrievalSelection();
                        }
                    }
                }

                return options;
            }
        }
    }
}