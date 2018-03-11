﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Milleret.JCDecauxLibrary {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="JCDecauxLibrary.IJCDecauxOperations")]
    public interface IJCDecauxOperations {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJCDecauxOperations/GetContracts", ReplyAction="http://tempuri.org/IJCDecauxOperations/GetContractsResponse")]
        string GetContracts(string key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJCDecauxOperations/GetContracts", ReplyAction="http://tempuri.org/IJCDecauxOperations/GetContractsResponse")]
        System.Threading.Tasks.Task<string> GetContractsAsync(string key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJCDecauxOperations/GetStationsFromTown", ReplyAction="http://tempuri.org/IJCDecauxOperations/GetStationsFromTownResponse")]
        string GetStationsFromTown(string key, string town);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJCDecauxOperations/GetStationsFromTown", ReplyAction="http://tempuri.org/IJCDecauxOperations/GetStationsFromTownResponse")]
        System.Threading.Tasks.Task<string> GetStationsFromTownAsync(string key, string town);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IJCDecauxOperationsChannel : Milleret.JCDecauxLibrary.IJCDecauxOperations, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class JCDecauxOperationsClient : System.ServiceModel.ClientBase<Milleret.JCDecauxLibrary.IJCDecauxOperations>, Milleret.JCDecauxLibrary.IJCDecauxOperations {
        
        public JCDecauxOperationsClient() {
        }
        
        public JCDecauxOperationsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public JCDecauxOperationsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public JCDecauxOperationsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public JCDecauxOperationsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetContracts(string key) {
            return base.Channel.GetContracts(key);
        }
        
        public System.Threading.Tasks.Task<string> GetContractsAsync(string key) {
            return base.Channel.GetContractsAsync(key);
        }
        
        public string GetStationsFromTown(string key, string town) {
            return base.Channel.GetStationsFromTown(key, town);
        }
        
        public System.Threading.Tasks.Task<string> GetStationsFromTownAsync(string key, string town) {
            return base.Channel.GetStationsFromTownAsync(key, town);
        }
    }
}