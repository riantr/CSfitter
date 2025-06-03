using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSfitter.Models
{
    public class ColorSpaceRepository
    {
        public async Task<List<ColorSpace>> GetColorSpacesAsync()
        {
            // Simulate an asynchronous operation to fetch color spaces
            await Task.Delay(1000); // Simulating network delay
            return new List<ColorSpace>
            {
                new ColorSpace { Id = "sRGB", Name = "sRGB", Source = "https://www.w3.org/Graphics/Color/sRGB" },
                new ColorSpace { Id = "AdobeRGB", Name = "Adobe RGB (1998)", Source = "https://www.adobe.com/digitalimag/pdfs/AdobeRGB1998.pdf" },
                new ColorSpace { Id = "ProPhotoRGB", Name = "ProPhoto RGB", Source = "https://www.xrite.com/blog/prophoto-rgb-color-space" }
            };
        }
    }
}
