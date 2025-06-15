namespace dotnet_mvc_car_wash.Models
{
    public class WashTypeService
    {
        public static string GetDescription(WashType washType)
        {
            string description = "";

            switch (washType)
            {
                case WashType.Basic:
                    description = "Lavado, aspirado y encerado";
                    break;
                case WashType.Premium:
                    description = "Lavado, aspirado y encerado y limpieza profunda de asientos";
                    break;
                case WashType.Deluxe:
                    description = "Lavado, aspirado y encerado, limpieza profunda de asientos, corrección de pintura. Opción productos para lavado con tratamiento nanocerámico";
                    break;
                case WashType.LaJoya:
                    description = "Incluye todo más detalles a convenir, pulidos, tratamientos hidrofóbicos, entre otros";
                    break;
                default:
                    description = "";
                    break;
            }

            return description;
        }

        public static decimal GetPrice(WashType washType)
        {
            decimal price = 0;

            switch (washType)
            {
                case WashType.Basic:
                    price = 8000;
                    break;
                case WashType.Premium:
                    price = 12000;
                    break;
                case WashType.Deluxe:
                    price = 20000;
                    break;
                case WashType.LaJoya:
                    price = 0; // A convenir
                    break;
                default:
                    price = 0;
                    break;
            }

            return price;
        }

        public static string GetPriceDisplay(WashType washType)
        {
            string priceText = "";

            if (washType == WashType.LaJoya)
            {
                priceText = "A convenir";
            }
            else
            {
                decimal price = GetPrice(washType);
                priceText = "₡" + price.ToString("N0");
            }

            return priceText;
        }

        public static decimal CalculateIVA(decimal basePrice)
        {
            decimal ivaPercentage = 0.13m; // 13%
            decimal ivaAmount = basePrice * ivaPercentage;
            return ivaAmount;
        }

        public static decimal CalculateTotalPrice(decimal basePrice)
        {
            decimal ivaAmount = CalculateIVA(basePrice);
            decimal totalPrice = basePrice + ivaAmount;
            return totalPrice;
        }
    }
}
