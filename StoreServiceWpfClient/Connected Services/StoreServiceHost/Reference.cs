﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreServiceWpfClient.StoreServiceHost {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StoreServiceHost.IStoreService")]
    public interface IStoreService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/CheckLogin", ReplyAction="http://tempuri.org/IStoreService/CheckLoginResponse")]
        bool CheckLogin(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/CheckLogin", ReplyAction="http://tempuri.org/IStoreService/CheckLoginResponse")]
        System.Threading.Tasks.Task<bool> CheckLoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/Register", ReplyAction="http://tempuri.org/IStoreService/RegisterResponse")]
        string Register(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/Register", ReplyAction="http://tempuri.org/IStoreService/RegisterResponse")]
        System.Threading.Tasks.Task<string> RegisterAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetProducts", ReplyAction="http://tempuri.org/IStoreService/GetProductsResponse")]
        StorageLogicLibrary.StoreProduct[] GetProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetProducts", ReplyAction="http://tempuri.org/IStoreService/GetProductsResponse")]
        System.Threading.Tasks.Task<StorageLogicLibrary.StoreProduct[]> GetProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/BuyProduct", ReplyAction="http://tempuri.org/IStoreService/BuyProductResponse")]
        bool BuyProduct(string username, string productName, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/BuyProduct", ReplyAction="http://tempuri.org/IStoreService/BuyProductResponse")]
        System.Threading.Tasks.Task<bool> BuyProductAsync(string username, string productName, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetAllOrders", ReplyAction="http://tempuri.org/IStoreService/GetAllOrdersResponse")]
        StorageLogicLibrary.CustomerProduct[] GetAllOrders(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetAllOrders", ReplyAction="http://tempuri.org/IStoreService/GetAllOrdersResponse")]
        System.Threading.Tasks.Task<StorageLogicLibrary.CustomerProduct[]> GetAllOrdersAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetBalance", ReplyAction="http://tempuri.org/IStoreService/GetBalanceResponse")]
        double GetBalance(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreService/GetBalance", ReplyAction="http://tempuri.org/IStoreService/GetBalanceResponse")]
        System.Threading.Tasks.Task<double> GetBalanceAsync(string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStoreServiceChannel : StoreServiceWpfClient.StoreServiceHost.IStoreService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StoreServiceClient : System.ServiceModel.ClientBase<StoreServiceWpfClient.StoreServiceHost.IStoreService>, StoreServiceWpfClient.StoreServiceHost.IStoreService {
        
        public StoreServiceClient() {
        }
        
        public StoreServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StoreServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StoreServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StoreServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CheckLogin(string username, string password) {
            return base.Channel.CheckLogin(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> CheckLoginAsync(string username, string password) {
            return base.Channel.CheckLoginAsync(username, password);
        }
        
        public string Register(string username) {
            return base.Channel.Register(username);
        }
        
        public System.Threading.Tasks.Task<string> RegisterAsync(string username) {
            return base.Channel.RegisterAsync(username);
        }
        
        public StorageLogicLibrary.StoreProduct[] GetProducts() {
            return base.Channel.GetProducts();
        }
        
        public System.Threading.Tasks.Task<StorageLogicLibrary.StoreProduct[]> GetProductsAsync() {
            return base.Channel.GetProductsAsync();
        }
        
        public bool BuyProduct(string username, string productName, int quantity) {
            return base.Channel.BuyProduct(username, productName, quantity);
        }
        
        public System.Threading.Tasks.Task<bool> BuyProductAsync(string username, string productName, int quantity) {
            return base.Channel.BuyProductAsync(username, productName, quantity);
        }
        
        public StorageLogicLibrary.CustomerProduct[] GetAllOrders(string username) {
            return base.Channel.GetAllOrders(username);
        }
        
        public System.Threading.Tasks.Task<StorageLogicLibrary.CustomerProduct[]> GetAllOrdersAsync(string username) {
            return base.Channel.GetAllOrdersAsync(username);
        }
        
        public double GetBalance(string username) {
            return base.Channel.GetBalance(username);
        }
        
        public System.Threading.Tasks.Task<double> GetBalanceAsync(string username) {
            return base.Channel.GetBalanceAsync(username);
        }
    }
}
