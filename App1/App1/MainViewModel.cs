using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace App1
{
    public class MainViewModel : BindableObject
    {
        private ObservableCollection<Item> allTasks = new ObservableCollection<Item>();
        private string description;
        private int num = 0;
        private Color choosedColor = Color.Lime;
        private Color Red = Color.Red;
        private Color White = Color.White;
        private Color Yellow = Color.Yellow;
        private Color Lime = Color.Lime;
        private Color Cyan = Color.Cyan;
        private Color Blue = Color.Blue;
        private Color Magenta = Color.Magenta;

        public ICommand SetRed
        {
            get
            {
                return new Command(() =>
                {
                    choosedColor = Red;
                }
                );
            }
        }
        public ICommand SetWhite
        {
            get
            {
                return new Command(() =>
                {
                    choosedColor = White;
                }
                );
            }
        }
        public ICommand SetYellow
        {
            get
            {
                return new Command(() =>
                {
                    choosedColor = Yellow;
                }
                );
            }
        }
        public ICommand SetLime
        {
            get
            {
                return new Command(() =>
                {
                    choosedColor = Lime;
                }
                );
            }
        }
        public ICommand SetCyan
        {
            get
            {
                return new Command(() =>
                {
                    choosedColor = Cyan;
                }
                );
            }
        }
        public ICommand SetBlue
        {
            get
            {
                return new Command(() =>
                {
                    choosedColor = Blue;
                }
                );
            }
        }
        public ICommand SetMagenta
        {
            get
            {
                return new Command(() =>
                {
                    choosedColor = Magenta;
                }
                );
            }
        }
        public ICommand AddTask
        {
            get
            {
                return new Command(() =>
                {
                    if(description != null)
                    {
                        AllTasks.Add(new Item() { color = choosedColor.ToString(), description = this.description, num = this.num, normalColor = choosedColor.ToString()});
                    }
                }
                );

            }
        }
        public ICommand DeleteAll
        {
            get
            {
                return new Command(() =>
                {
                    AllTasks.Clear();
                }
                );

            }
        }


        public ICommand DeleteChoosed
        {
            get
            {
                return new Command(() =>
                {
                    int size = allTasks.Count;
                    for (int i = 0; i < size; i++)
                    {
                        if(allTasks[i].Done)
                        {
                            allTasks.Remove(allTasks[i]);
                            size--;
                            i--;
                        }
                    }
                }
                );

            }
        }


        public ObservableCollection<Item> AllTasks
        {
            get
            {
                return allTasks;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if(!(value == description))
                {
                    description = value;
                }
                OnPropertyChanged("Description");
            }
        }
        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                if (!(value == num))
                {
                    num = value;
                }
                OnPropertyChanged("Num");
            }
        }


    };


    public class Item : BindableObject
    {
        private bool done = false;
        private TextDecorations textDecoration = TextDecorations.None;
        public string description;
        public string color;
        public int num = 0;
        private string doneColor = Color.Gray.ToString();
        public string normalColor;
        public bool isSelected;

        private Color StringToColor(string color)
        {
            string[] newColor = color.Split(',');
            double.TryParse(newColor[1].Substring(3), out double R);
            double.TryParse(newColor[2].Substring(3), out double G);
            double.TryParse(newColor[3].Substring(3), out double B);
            double.TryParse(newColor[0].Substring(10), out double A);
            return Color.FromRgba(R, G, B, A);

        }

        public Color DoneColor
        {
            get
            {
                return StringToColor(doneColor);
            }
        }


        public Color NormalColor
        {
            get
            {
                return StringToColor(normalColor);
            }
        }
        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
                OnPropertyChanged("Num");
            }
        }
        public Color COLOR 
        {
           get
            {
                return StringToColor(color);
            }
            set
            {
                if(done)
                {
                    color = doneColor;
                }
                else
                {
                    color = normalColor;
                }
                
                OnPropertyChanged("COLOR");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }


        public bool Done
        {
            get
            {
                return done;
            }
            set
            {
                done = value;
                System.Diagnostics.Debug.WriteLine(done);
                OnPropertyChanged("Done");
                TextDecoration = TextDecorations.Strikethrough;
                COLOR = StringToColor(doneColor);
            }
        }

        public TextDecorations TextDecoration
        {
            get
            {
                return textDecoration;
            }
            set
            {
                if (done)
                    textDecoration = TextDecorations.Strikethrough;
                else
                    textDecoration = TextDecorations.None;
                OnPropertyChanged();
            }
        }
    }
}
