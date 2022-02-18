using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.InputFiles;
namespace Telegram_bot
{
    class Program
    {
        //НАЗВАНИЕ КНОПОК КЛАВИАТУРЫ

        private const string TEXT_1 = "🗒 Программа для тренировки";
        private const string TEXT_2 = "💪 Упражнения";
        private const string TEXT_3 = "🎵 Музыка";
        private const string TEXT_4 = "🎥 Видео";
        private static string token { get; set; } = "your token";
        static TelegramBotClient Bot;
        static void Main(string[] args)
        {
            Bot = new TelegramBotClient(token);
            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;


            var me = Bot.GetMeAsync().Result;
            Console.WriteLine(me.FirstName);


            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        //ОБРАБОТКА INLINE-КНОПОК

        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs e)
        {
            var id = e.CallbackQuery.From.Id;
            var buttonText = e.CallbackQuery.Data;
            var name = $"{e.CallbackQuery.From.FirstName} {e.CallbackQuery.From.LastName}";
            Console.WriteLine($"{name} нажал кнопку {buttonText}");

            //НАЗНАЧЕНИЕ АУДИО ФАЙЛОВ

            var fs1 = System.IO.File.OpenRead(@"C:\Users\lette\Desktop\Telegram_bot\La Ciudad.mp3"); //Путь зависит от расположения папки проекта
            var fs2 = System.IO.File.OpenRead(@"C:\Users\lette\Desktop\Telegram_bot\Slowdive-Star Roving.mp3");
            var fs3 = System.IO.File.OpenRead(@"C:\Users\lette\Desktop\Telegram_bot\The_Amazons-Stay_With_Me.mp3");
            var fs4 = System.IO.File.OpenRead(@"C:\Users\lette\Desktop\Telegram_bot\The Chevin-Champion.mp3");
            var fs5 = System.IO.File.OpenRead(@"C:\Users\lette\Desktop\Telegram_bot\Public Order-Feels Like Summer.mp3");
            var fs6 = System.IO.File.OpenRead(@"C:\Users\lette\Desktop\Telegram_bot\John Newman-Love Me Again.mp3");

            switch (e.CallbackQuery.Data)
            {

                //МОДУЛЬ "ГОТОВАЯ ТРЕНИРОВКА"

                case "Эктоморф":
                    await Bot.SendTextMessageAsync(id, "Тренировка для эктоморфа - шестидневный сплит ✅" + "\n _____________________________________________________ \n" +
"\n 1⃣ Первый день: грудь \n" + "\n" +
@"Жим лежа   4х6-8
Жим лежа на наклонной скамье   4х6-8
Разведения гантелей лежа   3-4х8-10
Отжимания от брусьев   4 подхода по 6-8 повторений (использовать дополнительное отягощение) " + "\n" +
"\n 2⃣ Второй день: спина \n" + "\n" +
@"Подтягивания или тяга верхнего блока к груди   4х8
 Тяга штанги в наклоне   4х6
 Становая тяга   3х6" + "\n" +
 "\n 3⃣ Третий день: трицепс \n" + "\n" +
 @"Жим лежа узким хватом   4х6-8
Французский жим лежа   4х8
Французский жим сидя гантелью двумя руками   4х8" + "\n" +
"\n 4⃣ Четвёртый день: бицепс  \n" + "\n" +
 @"Подъем штанги на бицепс стоя   4х8-10
Подъем гантелей на бицепс сидя   4х8-10
Подъем штанги на бицепс обратным хватом   4х8-10" + "\n" +
"\n 5⃣ Пятый день: дельты \n" + "\n" +
 @"Жим штанги стоя с груди вверх   4х6-8
Махи гантелями в стороны   4х8-10
Шраги со штангой   4х10-12" + "\n" +
"\n 6⃣ Шестой день: ноги \n" + "\n" +
 @"Приседания со штангой на плечах   4х6
Жим ногами в станке   4х6-8
Подъемы на мыски в тренажере   4х10-12" + "\n" +
"\n 7⃣ Седьмой день: выходной \n");
                    break;

                case "Эндоморф":
                    await Bot.SendTextMessageAsync(id, "Тренировка для эндоморфа - четырёхдневный сплит ✅" + "\n _____________________________________________________ \n" +
"\n 1⃣ Первый день: ноги \n" + "\n" +
@"Приседания со штангой (4 подхода по 8 повторений);
Жим ногами в тренажере (4х8);
Разгибание ног сидя (4х8-12);
Мертвая тяга (4х8)" + "\n" +
"\n 2⃣ Второй день: грудь, трицепс \n" + "\n" +
@"Жим штанги лежа на наклонной скамье (4х8-10);
Жим гантелей на наклонной скамье (4х8-10);
Разводка гантелей (4х8-12);
Отжимания на узких брусьях с дополнительным весом (4х8-10);
Французский жим (4х8-10)" + "\n" +
"\n 3⃣ Третий день: спина, бицепс \n" + "\n" +
@"Подтягивания широким хватом (4 подхода до отказа);
Тяга штанги в наклоне (4х8-10);
Тяга верхнего блока (4х8-10);
Подьем штанги на бицепс стоя (4х8-10);
Молоток для бицепса (4х8-10);
Подьем гантели на бицепс сидя (4х8-10)" + "\n" +
"\n 4⃣ Четвёртый день: дельты, трапеция, пресс  \n" + "\n" +
@"Армейский жим (4х8-10);
Подьём штанги к подбородку широким хватом (4х8-10);
Шраги со штангой (4х8-10);
2-3 упражнения для пресса (4х15-30)");
                    break;

                case "Мезоморф":
                    await Bot.SendTextMessageAsync(id, "Тренировка для мезоморфа - трёхдневный сплит ✅" + "\n _____________________________________________________ \n" +
"\n 1⃣ Первый день: спина, плечи \n" + "\n" +
@"Подтягивания на перекладине (4 подхода до отказа);
Тяга штанги в наклоне (4x8-12 повторений);
Тяга верхнего блока (4x8-12);
Армейский жим (4x8-10);
Тяга штанги к подбородку (4x8-10);
Подъемы гантелей перед собой (4x8-12)" + "\n" +
"\n 2⃣ Второй день: грудь, руки \n" + "\n" +
@"Жим на наклонной скамье (4x8-12)
Жим гантелей на наклонной скамье (4x8-12)
Разводка гантелей (2x8-12)
Подъем штанги на бицепс (4x8-12)
Упражнение “Молот” (4x8-12)
Жим на горизонтальной скамье узким хватом (4x8-12)
Французский жим ( 4x8-12)" + "\n" +
"\n 3⃣ Третий день: ноги \n" + "\n" +
@"Приседания со штангой ( 2 разминочных + 3 рабочих подхода по 10-12 повторений);
Жим ногами на тренажёре (3x8-12);
Разгибания ног на тренажёре (3x8-12);
Подъемы на носки стоя (4x12-20)");
                    break;

                    //МОДУЛЬ "МУЗЫКА"

                case "4:31 | ODESZA - La Ciudad":
                    var iof1 = new InputOnlineFile(fs1);
                    iof1.FileName = "ODESZA - La Ciudad.mp3";
                    var result1 = await Bot.SendAudioAsync(id,iof1);
                    break;

                case "5:38 | Slowdive - Star Roving":
                    var iof2 = new InputOnlineFile(fs2);
                    iof2.FileName = "Slowdive - Star Roving.mp3";
                    var result2 = await Bot.SendAudioAsync(id,iof2);
                    break;

                case "3:10 | The Amazons - Stay With Me":
                    var iof3 = new InputOnlineFile(fs3);
                    iof3.FileName = "The Amazons - Stay With Me.mp3";
                    var result3 = await Bot.SendAudioAsync(id,iof3);
                    break;

               case "3:44 | The Chevin - Champion":
                    var iof4 = new InputOnlineFile(fs4);
                    iof4.FileName = "The Chevin - Champion.mp3";
                    var result4 = await Bot.SendAudioAsync(id,iof4);
                    break;

               case "2:45 | Public Order - Feels Like Summer":
                    var iof5 = new InputOnlineFile(fs5);
                    iof5.FileName = "Public Order - Feels Like Summer.mp3";
                    var result5 = await Bot.SendAudioAsync(id,iof5);
                    break;
                    
               case "4:00 | John Newman - Love Me Again":
                    var iof6 = new InputOnlineFile(fs6);
                    iof6.FileName = "John Newman - Love Me Again.mp3";
                    var result6 = await Bot.SendAudioAsync(id,iof6);
                    break;

                    //МОДУЛЬ "УПРАЖНЕНИЯ"

                case "Бицепс":
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/poocherednoe-sgibanie-ruk-s-gantelyami-na-predplechya.jpg", "Сгибание рук с гантелями боковым хватом");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/podem-ganteli-na-biceps-odnoj-rukoj.jpg", "Подъем гантели с упором на колено");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/sgibanie-ruk-so-shtangoj-hvatom-sverhu.jpg", "Сгибание рук со штангой передним хватом");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/sgibanie-ruk-na-biceps-sidya-so-shtangoj.jpg", "Сгибание рук со штангой, с упором локтя в скамью Скотта");
                    break;

                case "Трицепс":
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/razgibanie-ruki-hvatom-snizu-v-krossovere.jpg","Разгибание рук обратным хватом в кроссовере (верхний блок)");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/razgibanie-ruk-s-gantelyu-iz-za-golovy.jpg","Разгибание рук с гантелей из-за головы");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/zhim-gantelej-pered-soboj-s-vrashcheniem-kistej-sidya.jpg","Жим гантель перед собой с поворотом кисти");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2018/06/razgibanie-ruk-obratnym-v-krossovere-verhnij-blok.jpg","Разгибание рук в кроссовере (верхний блок)");
                    break;

                case "Грудь":
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2018/06/svedenie-ruk-na-grud-v-trenazhere-babochka.jpg","Сведение рук на грудь в тренажере (баттерфляй, бабочка)");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/zhim-lyozha.jpg","Жим лежа");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/podyom-gantelej-na-grud-lezha-na-skame.jpg","Разведение гантелей лежа на скамье (разводка)");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/otzhimaniya-na-brusyah.jpg","Отжимания на брусьях");
                    break;

                case "Трапеция":
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/razvedenie-ruk-v-storony-v-trenazhere.jpg","Разведение рук в стороны в тренажере");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/perekrestnye-mahi-rukami-nazad-v-krossovere.jpg","Перекрестные махи руками назад в кроссовере (верхний блок)");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/podem-ruk-v-storony-s-gantelyami.jpg","Подъем рук в стороны с гантелями");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/podem-ruk-v-storony-s-gantelyami-v-naklone.jpg","Подъем рук в стороны с гантелями в наклоне");
                    break;

                case "Пресс":
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/podem-nog-sidya-na-skame-na-press.jpg","Подъем ног сидя на скамье на пресс «складка»");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/podem-tulovishcha-na-skame-s-otricatelnym-naklonom.jpg","Подъем туловища на пресс на скамье с наклоном");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/sgibanie-nog-na-press-na-turnike.jpg","Сгибание ног на пресс на турнике");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/skruchivaniya-v-trenazhere-na-press.jpg","Скручивание в тренажере на пресс");
                    break;

                case "Ноги":
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/gakk-prisedaniya-v-trenazhere.jpg","Приседания в Гакк тренажере");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/razgibaniya-nog-v-trenazhere.jpg","Разгибание ног в тренажере");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/podyom-noskami-sidya-v-trenazhere.jpg","Подъём носками сидя в тренажере");
                    await Bot.SendPhotoAsync(id, photo: "https://xmuskul.ru/uprazhneniya/wp-content/uploads/2017/05/svedenie-beder-v-trenazhere.jpg","Сведение бедер в тренажере");
                    break;
            }

            await Bot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, $"Вы нажали кнопку {buttonText}");
        }




        private static async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            string name = $"{msg.From.FirstName} {msg.From.LastName}";      //Показывает имя, кто написал сообщение

            if (msg.Text != null)
            {
                Console.WriteLine($" {name} отправил сообщение: {msg.Text} ");    //Показывает кто какое сообщение написал

                switch (msg.Text) // назначение кнопок
                {
                    case "/start":
                       
                        var start = await Bot.SendTextMessageAsync(msg.Chat.Id, @" Здравствуйте!
Вы вошли в FitnessExercisesBot
Хорошей тренировки 😉", replyMarkup: GetButtons());
                        break;

                    case TEXT_1: // кнопка 1
                        var m1 = await Bot.SendTextMessageAsync(msg.Chat.Id, " Выберите свой тип телосложения: ");
                        var inlineKeyboard_1 = new InlineKeyboardMarkup(new[]
                        {
                            new []
                            {
                        InlineKeyboardButton.WithCallbackData("Эктоморф"),
                        InlineKeyboardButton.WithCallbackData("Эндоморф"),
                        InlineKeyboardButton.WithCallbackData("Мезоморф")
                            }
                        });
                        var pic1 = await Bot.SendPhotoAsync(chatId: msg.Chat.Id, photo: "https://img.championat.com/i/69/24/1493976924552821685.jpg", replyMarkup: inlineKeyboard_1);
                        break;


                    case TEXT_2: //кнопка 2
                        var m2 = await Bot.SendTextMessageAsync(msg.Chat.Id, " Выберите группу мышц:  ");
                        var inlineKeyboard_2 = new InlineKeyboardMarkup(new[]
                        {
                            new []
                            {
                        InlineKeyboardButton.WithCallbackData("Бицепс"),
                        InlineKeyboardButton.WithCallbackData("Трицепс")
                            },
                             new []
                            {
                        InlineKeyboardButton.WithCallbackData("Грудь"),
                        InlineKeyboardButton.WithCallbackData("Трапеция")
                            }, new []
                            {
                        InlineKeyboardButton.WithCallbackData("Пресс"),
                        InlineKeyboardButton.WithCallbackData("Ноги")
                            }
                        });
                        var pic2 = await Bot.SendPhotoAsync(chatId: msg.Chat.Id, photo: "https://b--f.ru/wp-content/uploads/anatomy.jpg", replyMarkup: inlineKeyboard_2);
                        break;


                    case TEXT_3: //кнопка 3 

                        var inlineKeyboard_3 = new InlineKeyboardMarkup(new[]
                         {
                             new []
                            {
                        InlineKeyboardButton.WithCallbackData("4:31 | ODESZA - La Ciudad")
                            },
                             new []
                            {
                        InlineKeyboardButton.WithCallbackData("5:38 | Slowdive - Star Roving")
                            },
                             new []
                            {
                        InlineKeyboardButton.WithCallbackData("3:10 | The Amazons - Stay With Me")
                            },
                             new []
                            {
                        InlineKeyboardButton.WithCallbackData("3:44 | The Chevin - Champion")
                            },
                             new []
                            {
                        InlineKeyboardButton.WithCallbackData("2:45 | Public Order - Feels Like Summer")
                            },
                             new []
                            {
                        InlineKeyboardButton.WithCallbackData("4:00 | John Newman - Love Me Again")
                            }
                        });

                        var m3 = await Bot.SendTextMessageAsync(msg.Chat.Id, "🎧 Музыка для фитнеса: ", replyMarkup: inlineKeyboard_3);
                        break;





                    case TEXT_4:
                        
                        var inlineKeyboard_4 = new InlineKeyboardMarkup(new[]
                         {
                             new []
                            {
                        InlineKeyboardButton.WithUrl("БИЦЕПСЫ. 10 УПРАЖНЕНИЙ", "https://www.youtube.com/watch?v=A087uxA8Sw4"),
                            },
                             new []
                            {
                        InlineKeyboardButton.WithUrl("ТРИЦЕПС. 5 БАЗОВЫХ УПРАЖНЕНИЙ", "https://www.youtube.com/watch?v=pSMKrN6LWrw"),
                            },
                             new []
                            {
                        InlineKeyboardButton.WithUrl("ГРУДНЫЕ МЫШЦЫ. 5 БАЗОВЫХ УПРАЖНЕНИЙ", "https://www.youtube.com/watch?v=oTzEfsTu6IE&list=PLlZTYwUk9OWn6Bm8kdR81RPPrP5umOm19&index=3"),
                            },
                             new []
                            {
                        InlineKeyboardButton.WithUrl("ПЛЕЧИ. 5 БАЗОВЫХ УПРАЖНЕНИЙ", "https://www.youtube.com/watch?v=Pu9VxPLw0Cs&list=PLlZTYwUk9OWn6Bm8kdR81RPPrP5umOm19&index=4"),
                            },
                         });
                        
                        var m4 = await Bot.SendTextMessageAsync(msg.Chat.Id,"Подборка видео с Youtube:", replyMarkup: inlineKeyboard_4);
                        break;

                    default:
                        await Bot.SendTextMessageAsync(msg.Chat.Id, " Извините, я вас не понимаю(", replyMarkup: GetButtons());
                        break;
                }
            }

        }



        private static IReplyMarkup GetButtons() //клавиатура
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = TEXT_1 }, new KeyboardButton { Text = TEXT_2 } },
                    new List<KeyboardButton> { new KeyboardButton { Text = TEXT_3 }, new KeyboardButton { Text = TEXT_4 } }
                },
                ResizeKeyboard = true
            };
        }
    }
}
