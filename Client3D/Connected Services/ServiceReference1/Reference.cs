﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client3D.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InputDate3D", Namespace="http://schemas.datacontract.org/2004/07/Teplo_WCF_Library")]
    [System.SerializableAttribute()]
    public partial class InputDate3D : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double HField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double[][][] Mass_uField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double TauField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double TimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double H {
            get {
                return this.HField;
            }
            set {
                if ((this.HField.Equals(value) != true)) {
                    this.HField = value;
                    this.RaisePropertyChanged("H");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[][][] Mass_u {
            get {
                return this.Mass_uField;
            }
            set {
                if ((object.ReferenceEquals(this.Mass_uField, value) != true)) {
                    this.Mass_uField = value;
                    this.RaisePropertyChanged("Mass_u");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Tau {
            get {
                return this.TauField;
            }
            set {
                if ((this.TauField.Equals(value) != true)) {
                    this.TauField = value;
                    this.RaisePropertyChanged("Tau");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OutputDate3D", Namespace="http://schemas.datacontract.org/2004/07/Teplo_WCF_Library")]
    [System.SerializableAttribute()]
    public partial class OutputDate3D : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double[][][] Culc_TeploField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[][][] Culc_Teplo {
            get {
                return this.Culc_TeploField;
            }
            set {
                if ((object.ReferenceEquals(this.Culc_TeploField, value) != true)) {
                    this.Culc_TeploField = value;
                    this.RaisePropertyChanged("Culc_Teplo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InputDate", Namespace="http://schemas.datacontract.org/2004/07/Teplo_WCF_Library")]
    [System.SerializableAttribute()]
    public partial class InputDate : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double HField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double[][] Mass_uField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double TauField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double TimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double H {
            get {
                return this.HField;
            }
            set {
                if ((this.HField.Equals(value) != true)) {
                    this.HField = value;
                    this.RaisePropertyChanged("H");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[][] Mass_u {
            get {
                return this.Mass_uField;
            }
            set {
                if ((object.ReferenceEquals(this.Mass_uField, value) != true)) {
                    this.Mass_uField = value;
                    this.RaisePropertyChanged("Mass_u");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Tau {
            get {
                return this.TauField;
            }
            set {
                if ((this.TauField.Equals(value) != true)) {
                    this.TauField = value;
                    this.RaisePropertyChanged("Tau");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OutputDate", Namespace="http://schemas.datacontract.org/2004/07/Teplo_WCF_Library")]
    [System.SerializableAttribute()]
    public partial class OutputDate : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double[][] Culc_TeploField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[][] Culc_Teplo {
            get {
                return this.Culc_TeploField;
            }
            set {
                if ((object.ReferenceEquals(this.Culc_TeploField, value) != true)) {
                    this.Culc_TeploField = value;
                    this.RaisePropertyChanged("Culc_Teplo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ICulcService")]
    public interface ICulcService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICulcService/CulcTeploParal3D", ReplyAction="http://tempuri.org/ICulcService/CulcTeploParal3DResponse")]
        Client3D.ServiceReference1.OutputDate3D CulcTeploParal3D(Client3D.ServiceReference1.InputDate3D inputMatrixes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICulcService/CulcTeploParal3D", ReplyAction="http://tempuri.org/ICulcService/CulcTeploParal3DResponse")]
        System.Threading.Tasks.Task<Client3D.ServiceReference1.OutputDate3D> CulcTeploParal3DAsync(Client3D.ServiceReference1.InputDate3D inputMatrixes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICulcService/CulcTeploPosl3D", ReplyAction="http://tempuri.org/ICulcService/CulcTeploPosl3DResponse")]
        Client3D.ServiceReference1.OutputDate3D CulcTeploPosl3D(Client3D.ServiceReference1.InputDate3D inputMatrixes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICulcService/CulcTeploPosl3D", ReplyAction="http://tempuri.org/ICulcService/CulcTeploPosl3DResponse")]
        System.Threading.Tasks.Task<Client3D.ServiceReference1.OutputDate3D> CulcTeploPosl3DAsync(Client3D.ServiceReference1.InputDate3D inputMatrixes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICulcService/CulcTeploParal", ReplyAction="http://tempuri.org/ICulcService/CulcTeploParalResponse")]
        Client3D.ServiceReference1.OutputDate CulcTeploParal(Client3D.ServiceReference1.InputDate inputMatrixes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICulcService/CulcTeploParal", ReplyAction="http://tempuri.org/ICulcService/CulcTeploParalResponse")]
        System.Threading.Tasks.Task<Client3D.ServiceReference1.OutputDate> CulcTeploParalAsync(Client3D.ServiceReference1.InputDate inputMatrixes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICulcService/CulcTeploPosl", ReplyAction="http://tempuri.org/ICulcService/CulcTeploPoslResponse")]
        Client3D.ServiceReference1.OutputDate CulcTeploPosl(Client3D.ServiceReference1.InputDate inputMatrixes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICulcService/CulcTeploPosl", ReplyAction="http://tempuri.org/ICulcService/CulcTeploPoslResponse")]
        System.Threading.Tasks.Task<Client3D.ServiceReference1.OutputDate> CulcTeploPoslAsync(Client3D.ServiceReference1.InputDate inputMatrixes);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICulcServiceChannel : Client3D.ServiceReference1.ICulcService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CulcServiceClient : System.ServiceModel.ClientBase<Client3D.ServiceReference1.ICulcService>, Client3D.ServiceReference1.ICulcService {
        
        public CulcServiceClient() {
        }
        
        public CulcServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CulcServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CulcServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CulcServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client3D.ServiceReference1.OutputDate3D CulcTeploParal3D(Client3D.ServiceReference1.InputDate3D inputMatrixes) {
            return base.Channel.CulcTeploParal3D(inputMatrixes);
        }
        
        public System.Threading.Tasks.Task<Client3D.ServiceReference1.OutputDate3D> CulcTeploParal3DAsync(Client3D.ServiceReference1.InputDate3D inputMatrixes) {
            return base.Channel.CulcTeploParal3DAsync(inputMatrixes);
        }
        
        public Client3D.ServiceReference1.OutputDate3D CulcTeploPosl3D(Client3D.ServiceReference1.InputDate3D inputMatrixes) {
            return base.Channel.CulcTeploPosl3D(inputMatrixes);
        }
        
        public System.Threading.Tasks.Task<Client3D.ServiceReference1.OutputDate3D> CulcTeploPosl3DAsync(Client3D.ServiceReference1.InputDate3D inputMatrixes) {
            return base.Channel.CulcTeploPosl3DAsync(inputMatrixes);
        }
        
        public Client3D.ServiceReference1.OutputDate CulcTeploParal(Client3D.ServiceReference1.InputDate inputMatrixes) {
            return base.Channel.CulcTeploParal(inputMatrixes);
        }
        
        public System.Threading.Tasks.Task<Client3D.ServiceReference1.OutputDate> CulcTeploParalAsync(Client3D.ServiceReference1.InputDate inputMatrixes) {
            return base.Channel.CulcTeploParalAsync(inputMatrixes);
        }
        
        public Client3D.ServiceReference1.OutputDate CulcTeploPosl(Client3D.ServiceReference1.InputDate inputMatrixes) {
            return base.Channel.CulcTeploPosl(inputMatrixes);
        }
        
        public System.Threading.Tasks.Task<Client3D.ServiceReference1.OutputDate> CulcTeploPoslAsync(Client3D.ServiceReference1.InputDate inputMatrixes) {
            return base.Channel.CulcTeploPoslAsync(inputMatrixes);
        }
    }
}
