﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Librox2.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.LoginUsuariosSoap")]
    public interface LoginUsuariosSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento US1 del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ValidUser", ReplyAction="*")]
        Librox2.ServiceReference2.ValidUserResponse ValidUser(Librox2.ServiceReference2.ValidUserRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ValidUser", ReplyAction="*")]
        System.Threading.Tasks.Task<Librox2.ServiceReference2.ValidUserResponse> ValidUserAsync(Librox2.ServiceReference2.ValidUserRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ValidUserRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ValidUser", Namespace="http://tempuri.org/", Order=0)]
        public Librox2.ServiceReference2.ValidUserRequestBody Body;
        
        public ValidUserRequest() {
        }
        
        public ValidUserRequest(Librox2.ServiceReference2.ValidUserRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ValidUserRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string US1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string PASS;
        
        public ValidUserRequestBody() {
        }
        
        public ValidUserRequestBody(string US1, string PASS) {
            this.US1 = US1;
            this.PASS = PASS;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ValidUserResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ValidUserResponse", Namespace="http://tempuri.org/", Order=0)]
        public Librox2.ServiceReference2.ValidUserResponseBody Body;
        
        public ValidUserResponse() {
        }
        
        public ValidUserResponse(Librox2.ServiceReference2.ValidUserResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ValidUserResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ValidUserResult;
        
        public ValidUserResponseBody() {
        }
        
        public ValidUserResponseBody(string ValidUserResult) {
            this.ValidUserResult = ValidUserResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface LoginUsuariosSoapChannel : Librox2.ServiceReference2.LoginUsuariosSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoginUsuariosSoapClient : System.ServiceModel.ClientBase<Librox2.ServiceReference2.LoginUsuariosSoap>, Librox2.ServiceReference2.LoginUsuariosSoap {
        
        public LoginUsuariosSoapClient() {
        }
        
        public LoginUsuariosSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LoginUsuariosSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginUsuariosSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginUsuariosSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Librox2.ServiceReference2.ValidUserResponse Librox2.ServiceReference2.LoginUsuariosSoap.ValidUser(Librox2.ServiceReference2.ValidUserRequest request) {
            return base.Channel.ValidUser(request);
        }
        
        public string ValidUser(string US1, string PASS) {
            Librox2.ServiceReference2.ValidUserRequest inValue = new Librox2.ServiceReference2.ValidUserRequest();
            inValue.Body = new Librox2.ServiceReference2.ValidUserRequestBody();
            inValue.Body.US1 = US1;
            inValue.Body.PASS = PASS;
            Librox2.ServiceReference2.ValidUserResponse retVal = ((Librox2.ServiceReference2.LoginUsuariosSoap)(this)).ValidUser(inValue);
            return retVal.Body.ValidUserResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Librox2.ServiceReference2.ValidUserResponse> Librox2.ServiceReference2.LoginUsuariosSoap.ValidUserAsync(Librox2.ServiceReference2.ValidUserRequest request) {
            return base.Channel.ValidUserAsync(request);
        }
        
        public System.Threading.Tasks.Task<Librox2.ServiceReference2.ValidUserResponse> ValidUserAsync(string US1, string PASS) {
            Librox2.ServiceReference2.ValidUserRequest inValue = new Librox2.ServiceReference2.ValidUserRequest();
            inValue.Body = new Librox2.ServiceReference2.ValidUserRequestBody();
            inValue.Body.US1 = US1;
            inValue.Body.PASS = PASS;
            return ((Librox2.ServiceReference2.LoginUsuariosSoap)(this)).ValidUserAsync(inValue);
        }
    }
}
