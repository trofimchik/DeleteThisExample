using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Data;

namespace DeleteThisExample
{
    class MainViewModel
    {
        public ICollectionView CollectionViewZero { get; private set; }
        public ICollectionView CollectionViewOne { get; private set; }
        public ObservableCollection<Model> Nums { get; private set; } = new ObservableCollection<Model>();
        public string RandomProp { get; set; }
        public int AnotherRandomProp { get; set; }

        public MainViewModel()
        {
            Nums.Add(new Model(1));
            Nums.Add(new Model(0));
            Nums.Add(new Model(1));
            Nums.Add(new Model(1));
            Nums.Add(new Model(0));

            CollectionViewZero = new CollectionViewSource { Source = Nums }.View;
            CollectionViewZero.Filter = ReturnZeroFilter;
            CollectionViewOne = new CollectionViewSource { Source = Nums }.View;
            CollectionViewOne.Filter = ReturnOneFilter;
        }

        private bool ReturnOneFilter(object item)
        {
            Model temp = item as Model;
            if (temp.Num == 1)
            {
                return true;
            }
            return false;
        }
        private bool ReturnZeroFilter(object item)
        {
            Model temp = item as Model;
            if (temp.Num == 0)
            {
                return true;
            }
            return false;
        }
    }
}
