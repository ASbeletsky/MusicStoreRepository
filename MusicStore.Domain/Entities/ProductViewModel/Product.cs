using MusicStore.WebUI.Models.ProductDetail;
using MusicStore.Domain.Helpers;


namespace MusicStore.Domain.Entities
{
    public partial class Product
    {
        public virtual DetailProductViewModel MakeModel(DetailProductViewModel model)
        {
            //Общие сведения о товаре
            model.Characteristics.Add(new Characteristic("Общие сведения"));
            model.Characteristics[0].Properties.Add("Id", new Field { Value = this.Id});
            model.Characteristics[0].Properties.Add("Name", new Field { Value = this.General.Name });
            model.Characteristics[0].Properties.Add("Price", new Field {Value = this.General.Price.ToString().ToPrice() });
            model.Characteristics[0].Properties.Add("Guaranty", new Field { Messege = "Гарантия", Value = string.Format("{0} месяцев", this.General.Guaranty) });
            model.Characteristics[0].Properties.Add("Desribtion", new Field { Messege = "Описание", Value = this.General.Desribtion });
            model.Characteristics[0].Properties.Add("Producer", new Field { Messege = "Производитель", Value = this.producer.Name });
            model.Characteristics[0].Properties.Add("Color", new Field { Messege = "Цвет", Value = this.color.Name });
            model.Characteristics[0].Properties.Add("Extra", new Field { Messege = "Дополнительно", Value = this.ExtraProperties });
            //Путь к изображению
            model.ImagePath = this.Image_path;

            return model;
        }
    }

    public partial class Guitar
    {
        public override DetailProductViewModel MakeModel(DetailProductViewModel model)
        {
            base.MakeModel(model);
            //Сведения о материалах
            model.Characteristics.Add(new Characteristic("Материалы"));
            model.Characteristics[1].Properties.Add("Mensure", new Field { Messege = "Мензура", Value = this.Material.Mensure });
            model.Characteristics[1].Properties.Add("Tuning_machines", new Field {Messege = "Колки", Value = this.Material.Tuning_machines });
            //Сведения о конструкции
            model.Characteristics.Add(new Characteristic("Конструкция"));
            model.Characteristics[2].Properties.Add("FretQuantity", new Field { Messege = "Количество ладов", Value = this.Construction.FretQuantity });
            model.Characteristics[2].Properties.Add("StringQuantity", new Field { Messege = "Количество струн", Value = this.Construction.StringQuantity });
            model.Characteristics[2].Properties.Add("Size", new Field { Messege = "Размер", Value = this.Construction.Size });
            model.Characteristics[2].Properties.Add("Set ", new Field { Messege = "В комплекте", Value = this.Set });

            return model;
        }
    }

    public partial class AcusticGuitar
    {
        public override DetailProductViewModel MakeModel(DetailProductViewModel model)
        {
            base.MakeModel(model);
            //Сведения о материалах
            model.Characteristics[1].Properties.Add("BottomDeka", new Field { Messege = "Нижняя дека", Value = this.MaterialAcustic.BottomDeka });
            model.Characteristics[1].Properties.Add("TopDeka", new Field { Messege = "Верхняя дека", Value = this.MaterialAcustic.TopDeka });
            model.Characteristics[1].Properties.Add("Neck", new Field { Messege = "Гриф", Value = this.MaterialAcustic.Neck });
            model.Characteristics[1].Properties.Add("NeckCover", new Field { Messege = "Накладка грифа", Value = this.MaterialAcustic.NeckCover });
            model.Characteristics[1].Properties.Add("Bridger", new Field { Messege = "Бридж", Value = this.MaterialAcustic.Bridge });
            //Сведения о звукоснимателях
            model.Characteristics.Add(new Characteristic("Звукосниматели"));
            model.Characteristics[3].Properties.Add("Pickup", new Field { Messege = "Звукосниматель", Value = this.Pickup });

            return model;
        }
    }
    public partial class ElectroAndBassGuitar
    {
        public override DetailProductViewModel MakeModel(DetailProductViewModel model)
        {
            base.MakeModel(model);
            //Сведения о материалах
            model.Characteristics[1].Properties.Add("Body", new Field { Messege = "Корпус", Value = this.MaterialEnB.BodyMaterial });
            model.Characteristics[1].Properties.Add("Neck", new Field { Messege = "Гриф", Value = this.MaterialEnB.NeckMaterial });
            model.Characteristics[1].Properties.Add("NeckCover", new Field { Messege = "Накладка грифа", Value = this.MaterialEnB.NeckCoverMaterial });
            //Сведения о конструкции
            model.Characteristics[2].Properties.Add("NeckMount", new Field { Messege = "Крепление грифа", Value = this.ConstructionEnB.NeckMount });
            model.Characteristics[2].Properties.Add("NeckSideView", new Field { Messege = "Профиль грифа", Value = this.ConstructionEnB.NeckSideView });
            model.Characteristics[2].Properties.Add("StringsThroughtBody", new Field { Messege = "Струны сквозь корпус", Value = this.ConstructionEnB.StringsThroughtBody });                       
            //Сведения о электронике
            model.Characteristics.Add(new Characteristic("Электроника"));
            model.Characteristics[3].Title = "Электроника";
            model.Characteristics[3].Properties.Add("PickupSchema", new Field { Messege = "Схема звукоснимателей", Value = this.ElectronicEnB.PickupSchema });
            model.Characteristics[3].Properties.Add("PickupSwitchers", new Field { Messege = "Переключатели", Value = this.ElectronicEnB.PickupSwitchers });
            model.Characteristics[3].Properties.Add("Regulators", new Field { Messege = "Регуляторы", Value = this.ElectronicEnB.Regulators });

            return model;
        }
    }

    public partial class Keyboard
    {
        public override DetailProductViewModel MakeModel(DetailProductViewModel model)
        {
            base.MakeModel(model);
            //Обшие сведения 
            model.Characteristics[0].Properties.Add("AcusticSystem", new Field { Messege = "Акустическая система", Value = this.GeneralKb.AcusticSystem });
            model.Characteristics[0].Properties.Add("Display", new Field { Messege = "Дисплей", Value = this.GeneralKb.Display });
            model.Characteristics[0].Properties.Add("Size", new Field { Messege = "Размер", Value = this.GeneralKb.Size });
            model.Characteristics[0].Properties.Add("Set", new Field { Messege = "В комплекте", Value = this.GeneralKb.Set });
            //Сведения о клавиатуре
            model.Characteristics.Add(new Characteristic("Клавиатура"));
            model.Characteristics[1].Properties.Add("KeyType", new Field { Messege = "Тип", Value = this.Keys.KeyType });
            model.Characteristics[1].Properties.Add("KeyMachanic", new Field { Messege = "Механика", Value = this.Keys.KeyMachanic });
            model.Characteristics[1].Properties.Add("KeyQuantity", new Field { Messege = "Количество клавиш", Value = string.Format("{0}", this.Keys.KeyQuantity) });
            model.Characteristics[1].Properties.Add("LevelTouchQuantity", new Field { Messege = "Количество уровней нажатия", Value = string.Format("{0}", this.Keys.LevelTouchQuantity)});
            model.Characteristics[1].Properties.Add("HasLighting", new Field { Messege = "Наличее подсветки", Value = (bool)this.Keys.HasLighting ? "Есть" : "Нет" });
            //Сведения о тембрах
            model.Characteristics.Add(new Characteristic("Тембры"));
            model.Characteristics[2].Properties.Add("Tembers", new Field { Messege = "Тембры", Value = this.Tembers.Tembers });
            model.Characteristics[2].Properties.Add("TemberQuantity", new Field { Messege = "Количество", Value = this.Tembers.TemberQuantity });
            model.Characteristics[2].Properties.Add("Polyphony", new Field { Messege = "Полифония", Value = this.Tembers.Polyphony });
            //Сведения о эфектах
            model.Characteristics.Add(new Characteristic("Эффекты"));
            model.Characteristics[3].Properties.Add("HasKeyDivision", new Field { Messege = "Разделения клавиатуры", Value = (bool)this.Effects.HasKeyDivision ? "Есть" : "Нет" });
            model.Characteristics[3].Properties.Add("HasTemberOverlay", new Field { Messege = "Перегрузка тембров", Value = (bool)this.Effects.HasTemberOverlay ? "Есть" : "Нет" });
            model.Characteristics[3].Properties.Add("Reverbration", new Field { Messege = "Ревербрация", Value = this.Effects.reverbration });
            //Сведения о акомпанименте
            model.Characteristics.Add(new Characteristic("Автоакомпанимент"));
            model.Characteristics[4].Properties.Add("HasAutoAccompaniment", new Field { Messege = "Наличее автоакомпанимента", Value = (bool)this.HasAutoAccompaniment ? "Есть" : "Нет" });            
            //Дополнительные сведения
            model.Characteristics.Add(new Characteristic("Дополнительно"));
            model.Characteristics[5].Properties.Add("Inputs", new Field { Messege = "Входы", Value = this.Inputs });
            model.Characteristics[5].Properties.Add("Outputs ", new Field { Messege = "Выходы", Value = this.Outputs });
            
            return model;
        }
    }

    public partial class Synthesizer
    {
        public override DetailProductViewModel MakeModel(DetailProductViewModel model)
        {
            base.MakeModel(model);
            //Сведения о клавиатуре
            model.Characteristics[1].Properties.Add("KeyHardness", new Field { Messege = "Жесткость клавиатуры", Value = this.KeySz.KeyHardness });
            model.Characteristics[1].Properties.Add("KeySize", new Field { Messege = "Размер клавиатуры", Value = this.KeySz.KeySize });
            //Сведения о эфектах
            model.Characteristics.Add(new Characteristic("Эффекты"));
            model.Characteristics[3].Properties.Add("Sempling", new Field { Messege = "Семплирование", Value = this.Sempling });
            model.Characteristics[3].Properties.Add("Sequence", new Field { Messege = "Секвенция", Value = this.Sequence });
            model.Characteristics[3].Properties.Add("ToneGenerator", new Field { Messege = "Генератор тонов", Value = this.ToneGenerator });
            //Сведения о акомпанименте
            model.Characteristics[4].Properties.Add("StileNumber", new Field { Messege = "Количество стилей", Value = this.AutoAccompaniment.AccompanimentStileNumber.ToString() });
            model.Characteristics[4].Properties.Add("Features", new Field { Messege = "Особености", Value = this.AutoAccompaniment.Features });
             
            return model;
        }
    }

    public partial class DigitalPiano
    {
        public override DetailProductViewModel MakeModel(DetailProductViewModel model)
        {
            base.MakeModel(model);
            //Сведения о акомпанименте
            model.Characteristics[4].Properties.Add("CompositionQuantity", new Field { Messege = "Колличество вструеных композиций", Value = this.CompositionQuantity });
            //Сведения о педалях
            model.Characteristics.Add(new Characteristic("Педали"));
            model.Characteristics[5].Properties.Add("Function", new Field { Messege = "Функции", Value = this.Pedals.PedalsFunction });
            model.Characteristics[5].Properties.Add("Quantity", new Field { Messege = "Количество", Value = this.Pedals.PedalsQuantity });
            //Дополнительные сведения
            model.Characteristics.Add(new Characteristic("Дополнительно"));
            model.Characteristics[6].Properties.Add("Metronom", new Field { Messege = "Метроном", Value = this.OtherFunctions.Metronom });
            model.Characteristics[6].Properties.Add("Staty", new Field { Messege = "Функция обучения", Value = this.OtherFunctions.StatyFunction });
            model.Characteristics[6].Properties.Add("Transponation", new Field { Messege = "Транспозиция", Value = this.OtherFunctions.Transponation });
            
            return model;
        }
    }
    public partial class AcusticDrum
    {
        public override DetailProductViewModel MakeModel(DetailProductViewModel model)
        {
            base.MakeModel(model);
            model.Characteristics[0].Properties.Add("Seria", new Field { Messege = "Серия", Value = this.Seria });
            model.Characteristics[0].Properties.Add("DrumQuantity ", new Field { Messege = "Количество барабанов", Value = this.DrumQuantity });
            model.Characteristics[0].Properties.Add("BassDrum", new Field { Messege = "Басс барабан", Value = this.BassDrum });
            model.Characteristics[0].Properties.Add("FloorTom", new Field { Messege = "Напольный том", Value = this.FloorTom });
            model.Characteristics[0].Properties.Add("FirstTom", new Field { Messege = "Первый том", Value = this.FirstTom });
            model.Characteristics[0].Properties.Add("SecondTom", new Field { Messege = "Второй том", Value = this.SecondTom });
            model.Characteristics[0].Properties.Add("SnareDrum", new Field { Messege = "Малый барабан", Value = this.SnareDrum });
            model.Characteristics[0].Properties.Add("Set", new Field { Messege = "В комплекте", Value = this.Set });
            model.Characteristics[0].Properties.Add("Material", new Field { Messege = "Материалы", Value = this.Material });
            
            return model;
        }
    }

    public partial class ElectroDrum
    {
        public override DetailProductViewModel MakeModel(DetailProductViewModel model)
        {
            base.MakeModel(model);
            model.Characteristics[0].Properties.Add("Inputs", new Field { Messege = "Входы", Value = this.Inputs });
            model.Characteristics[0].Properties.Add("Outputs", new Field { Messege = "Выходы", Value = this.Outputs });
            model.Characteristics[0].Properties.Add("Size", new Field { Messege = "Размер", Value = this.Size });
            model.Characteristics[0].Properties.Add("Weight", new Field { Messege = "Вес", Value = this.Weight });
            //Сведения о конфигурации
            model.Characteristics.Add(new Characteristic("Конфигурация"));
            model.Characteristics[1].Properties.Add("Peds", new Field { Messege = "Педы", Value = this.Configuration.Peds });
            model.Characteristics[1].Properties.Add("Cembals", new Field { Messege = "Тарелки", Value = this.Configuration.Cembals });
            model.Characteristics[1].Properties.Add("Pedals", new Field { Messege = "Педали", Value = this.Configuration.Pedals });
            model.Characteristics[1].Properties.Add("Racks", new Field { Messege = "Стойки", Value = this.Configuration.Racks });
            //Сведения о тембрах
            model.Characteristics.Add(new Characteristic("Тембры"));
            model.Characteristics[2].Properties.Add("Tembers", new Field { Messege = "Тембры", Value = this.Tembers.Tembers });
            model.Characteristics[2].Properties.Add("Polyphony", new Field { Messege = "Полифония", Value = this.Tembers.Polyphony });
            
            return model;
        }
    }
}