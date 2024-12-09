// using System.ComponentModel;
// using UnityEngine;
// using UnityWeld.Binding;
//
// namespace Test
// {
//     [Binding]
//     public class ExViewModel : MonoBehaviour, INotifyPropertyChanged
//     {
//         [SerializeField]
//         private string _message;
//
//         [Binding]
//         public string Message
//         {
//             get
//             {
//                 return _message;
//             }
//             set
//             {
//                 if (_message != value)
//                 {
//                     _message = value;
//                     OnPropertyChanged(nameof(Message)); // 바인딩된 UI 업데이트
//                 }
//             }
//             
//         }
//
//         [Binding]
//         public void UpdateMessage(string message)
//         {
//             _message = message;
//         }
//         
//         private void OnPropertyChanged(string propertyName)
//         {
//             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//         }
//
//         public event PropertyChangedEventHandler PropertyChanged;
//     }
// }