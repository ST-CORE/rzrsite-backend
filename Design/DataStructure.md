Category {
    key int Id;
    string Name;
    int Weight;
    string Path /Crusher || /Boiler
    
    ++ CRUD
    
    [] Series {
        key int Id;
        int CategoryId;
        string Path;   /Fit-20-70 || /Fit-100-260 || /DC-20
        string Name;    Fit 20-70
        string Description;
        int Weight;
        
        ++ CRUD
        ++ GET Parameter_Value

        [] Advantage { 
            key int Id;
            key int SeriesId;
            string Title; =========> <span>Высокая эффективность<br/> (КПД 85-90%)</span> 
            int Weight;
            string IconUrl;

            ++ CRUD
        }

        [] Document { 
            key int Id;
            key int SeriesId;
            string Path;
            string Description;
            byte[] Bytes;

            ++ CRUD
            GET ( Url ) -> PDF: { path }
        }

        [] Product {
            key int Id;
            int SeriesId;
            string Name;
            string Title;
            int Price;
            bool InStock; ???????????????????
            int Weight;

            ++ CRUD

            PrimaryImage : Image

            [] Image {
                int Id;
                int ProductId;
                string ImageName;
                string Format; || JPG ALWAYS?
                byte[] FullImage;
                byte[] ThumbImage;
                int Weight;
                
                ++ CRUD
                ++ GET {URL} => {Series.Path}/{Product.Name}/{ImageName}.{Format}
                ++ GET {URL} => {Series.Path}/{Product.Name}/{ImageName}-Small.{Format}
            }

            [] Parameter_Value {
                int Id;
                int ProductId;
                int Weight;

                ++ CRUD

                Parameter {
                    int Id;
                    string Name;
                }
                
                Value { 
                    int Id;
                    int ParameterId;
                    string Value;
                }
            }
        }
    }
}