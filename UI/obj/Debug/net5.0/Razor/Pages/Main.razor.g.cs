#pragma checksum "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1bd1c93e6b867bacc2a91d11e2d9dc5404f2f0d7"
// <auto-generated/>
#pragma warning disable 1591
namespace UI.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Josh\Documents\Github\IPTracker\UI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Josh\Documents\Github\IPTracker\UI\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Josh\Documents\Github\IPTracker\UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Josh\Documents\Github\IPTracker\UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Josh\Documents\Github\IPTracker\UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Josh\Documents\Github\IPTracker\UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Josh\Documents\Github\IPTracker\UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Josh\Documents\Github\IPTracker\UI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Josh\Documents\Github\IPTracker\UI\_Imports.razor"
using UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Josh\Documents\Github\IPTracker\UI\_Imports.razor"
using UI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
using UI.Client.FormModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
using SharedModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
using System.Text.Json.Serialization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Main")]
    public partial class Main : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "main");
            __builder.AddAttribute(2, "b-kryesyjnmw");
#nullable restore
#line 10 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
     if (aliasDisplay)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
         foreach (var alias in aliasList)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "box top");
            __builder.AddAttribute(5, "b-kryesyjnmw");
            __builder.OpenElement(6, "p");
            __builder.AddAttribute(7, "class", "pingAlias");
            __builder.AddAttribute(8, "b-kryesyjnmw");
            __builder.AddContent(9, 
#nullable restore
#line 15 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
                                      alias

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 17 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
         
    }
    else
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "box top");
            __builder.AddAttribute(12, "b-kryesyjnmw");
            __builder.OpenElement(13, "p");
            __builder.AddAttribute(14, "class", "ipDisplay");
            __builder.AddAttribute(15, "b-kryesyjnmw");
            __builder.AddContent(16, 
#nullable restore
#line 22 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
                                  retrievalPacket.Ip

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 24 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(17, "div");
            __builder.AddAttribute(18, "class", "bottom");
            __builder.AddAttribute(19, "b-kryesyjnmw");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "authGrid");
            __builder.AddAttribute(22, "b-kryesyjnmw");
            __builder.OpenElement(23, "div");
            __builder.AddAttribute(24, "class", "authForms");
            __builder.AddAttribute(25, "b-kryesyjnmw");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(26);
            __builder.AddAttribute(27, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 29 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
                                  userform

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(28, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(29);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(30, "\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(31);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(32, "\r\n                    ");
                __builder2.OpenElement(33, "div");
                __builder2.AddAttribute(34, "class", "authFormSection");
                __builder2.AddAttribute(35, "b-kryesyjnmw");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(36);
                __builder2.AddAttribute(37, "placeholder", "Username");
                __builder2.AddAttribute(38, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 33 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
                                                                       userform.UserName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(39, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => userform.UserName = __value, userform.UserName))));
                __builder2.AddAttribute(40, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => userform.UserName));
                __builder2.AddAttribute(41, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(42, "Username");
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(43, "\r\n                    ");
                __builder2.OpenElement(44, "div");
                __builder2.AddAttribute(45, "class", "authFormSection");
                __builder2.AddAttribute(46, "b-kryesyjnmw");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(47);
                __builder2.AddAttribute(48, "placeholder", "Password");
                __builder2.AddAttribute(49, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 36 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
                                                                       userform.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(50, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => userform.Password = __value, userform.Password))));
                __builder2.AddAttribute(51, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => userform.Password));
                __builder2.AddAttribute(52, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(53, "Password");
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(54, "\r\n                    ");
                __builder2.OpenElement(55, "div");
                __builder2.AddAttribute(56, "class", "authFormSection");
                __builder2.AddAttribute(57, "b-kryesyjnmw");
                __builder2.OpenElement(58, "button");
                __builder2.AddAttribute(59, "class", "authButton buttonStyle");
                __builder2.AddAttribute(60, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 39 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
                                                                         CheckCredentials

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(61, "type", "submit");
                __builder2.AddAttribute(62, "b-kryesyjnmw");
                __builder2.AddContent(63, "Cache User");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(64, "\r\n                        ");
                __builder2.OpenElement(65, "button");
                __builder2.AddAttribute(66, "class", "authButton buttonStyle");
                __builder2.AddAttribute(67, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 40 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
                                                                         AddCredentials

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(68, "type", "submit");
                __builder2.AddAttribute(69, "b-kryesyjnmw");
                __builder2.AddContent(70, "Add User");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(71, "\r\n                        ");
                __builder2.OpenElement(72, "button");
                __builder2.AddAttribute(73, "class", "authButton buttonStyle");
                __builder2.AddAttribute(74, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 41 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
                                                                         GetAliases

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(75, "type", "submit");
                __builder2.AddAttribute(76, "b-kryesyjnmw");
                __builder2.AddContent(77, "Get Aliases For User");
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 45 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
             if (successSate)
            {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(78, "<div class=\"box authResult successState\" b-kryesyjnmw>\r\n                    Success\r\n                </div>");
#nullable restore
#line 50 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
            }
            else
            {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(79, "<div class=\"box authResult failureState\" b-kryesyjnmw>\r\n                    Failure\r\n                </div>");
#nullable restore
#line 56 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(80, "\r\n        ");
            __builder.OpenElement(81, "div");
            __builder.AddAttribute(82, "class", "controlGrid");
            __builder.AddAttribute(83, "b-kryesyjnmw");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(84);
            __builder.AddAttribute(85, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 60 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
                              keyForm

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(86, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(87);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(88, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(89);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(90, "\r\n                ");
                __builder2.OpenElement(91, "div");
                __builder2.AddAttribute(92, "class", "box controlForm");
                __builder2.AddAttribute(93, "b-kryesyjnmw");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(94);
                __builder2.AddAttribute(95, "style", "width: 100%; text-align: center;");
                __builder2.AddAttribute(96, "class", "controlInput");
                __builder2.AddAttribute(97, "placeholder", "InstanceKey");
                __builder2.AddAttribute(98, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 64 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
                                                                                                                                   keyForm.key

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(99, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => keyForm.key = __value, keyForm.key))));
                __builder2.AddAttribute(100, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => keyForm.key));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(101, "\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(102);
                __builder2.AddAttribute(103, "style", "width: 100%; text-align: center;");
                __builder2.AddAttribute(104, "class", "controlInput");
                __builder2.AddAttribute(105, "placeholder", "Alias");
                __builder2.AddAttribute(106, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 65 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
                                                                                                                             keyForm.alias

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(107, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => keyForm.alias = __value, keyForm.alias))));
                __builder2.AddAttribute(108, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => keyForm.alias));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(109, "\r\n                ");
                __builder2.OpenElement(110, "div");
                __builder2.AddAttribute(111, "class", "box controlForm");
                __builder2.AddAttribute(112, "b-kryesyjnmw");
                __builder2.OpenElement(113, "button");
                __builder2.AddAttribute(114, "class", "controlButton buttonStyle");
                __builder2.AddAttribute(115, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 68 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
                                                                        ClaimAlias

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(116, "type", "submit");
                __builder2.AddAttribute(117, "b-kryesyjnmw");
                __builder2.AddContent(118, "Claim Alias for User");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(119, "\r\n                    ");
                __builder2.OpenElement(120, "button");
                __builder2.AddAttribute(121, "class", "controlButton buttonStyle");
                __builder2.AddAttribute(122, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 69 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
                                                                        GetIP

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(123, "type", "submit");
                __builder2.AddAttribute(124, "b-kryesyjnmw");
                __builder2.AddContent(125, "Get IP for Alias");
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 76 "C:\Users\Josh\Documents\Github\IPTracker\UI\Pages\Main.razor"
      
    AuthPacket authPacket;
    UserForm userform;
    KeyForm keyForm;
    RetrievalPacket retrievalPacket;
    HttpClient client;
    bool aliasDisplay;
    List<string> aliasList;
    bool successSate;

    async void CheckCredentials()
    {
        authPacket.UserName = userform.UserName;
        authPacket.Password = userform.Password;
        try
        {
            var response = await client.PostAsJsonAsync("http://localhost:5005/api/auth", authPacket);
            authPacket = await response.Content.ReadFromJsonAsync<AuthPacket>();
        }
        catch (Exception e)
        {
            Console.WriteLine("No Response from api");
        }
        
        Console.WriteLine(authPacket.Success);
        successSate = authPacket.Success;
        StateHasChanged();
    }

    async void AddCredentials()
    {
        authPacket.UserName = userform.UserName;
        authPacket.Password = userform.Password;
        try
        {
            var response = await client.PostAsJsonAsync("http://localhost:5005/api/user", authPacket);
            authPacket = await response.Content.ReadFromJsonAsync<AuthPacket>();
        }
        catch (Exception e)
        {
            Console.WriteLine("No response from api");
        }
        Console.WriteLine(authPacket.Success);
        successSate = authPacket.Success;
        StateHasChanged();
    }

    async void ClaimAlias()
    {
        ClaimPacket packet = new ClaimPacket()
        {
            AuthPacket = authPacket,
            Alias = keyForm.alias,
            InstanceID = keyForm.key,
        };
        try
        {
            var response = await client.PostAsJsonAsync("http://localhost:5005/api/claim", packet);
            packet = await response.Content.ReadFromJsonAsync<ClaimPacket>();
        }
        catch (Exception e)
        {
            Console.WriteLine("No response from api");
        }
        Console.WriteLine(packet.Success);
        successSate = packet.Success;
        StateHasChanged();
    }

    async void GetAliases()
    {
        retrievalPacket = new RetrievalPacket()
        {
            AuthPacket = authPacket,
            Alias = keyForm.alias,
        };
        var packet = new AliasListPacket()
        {
            RetrievalPacket = retrievalPacket,
            Aliases = new List<string>()
        };
        try
        {
            var response = await client.PostAsJsonAsync("http://localhost:5005/api/list", packet);
            packet = await response.Content.ReadFromJsonAsync<AliasListPacket>();
        }
        catch (Exception e)
        {
            Console.WriteLine("No response from api");
        }
        
        Console.WriteLine($"Get Aliases returned {packet.Aliases.Count()} Aliases");
        aliasList.Clear();
        foreach (var alias in packet.Aliases)
        {
            Console.WriteLine(alias);
            aliasList.Add(alias);
        }
        aliasDisplay = true;
        successSate = packet.Success;
        StateHasChanged();
    }

    async void GetIP()
    {
        aliasDisplay = false;
        retrievalPacket = new RetrievalPacket()
        {
            AuthPacket = authPacket,
            Alias = keyForm.alias,
        };
        try
        {
            var response = await client.PostAsJsonAsync("http://localhost:5005/api/fetch", retrievalPacket);
            retrievalPacket = await response.Content.ReadFromJsonAsync<RetrievalPacket>();
        }
        catch (Exception e)
        {
            Console.WriteLine("No response from api");
        }
        successSate = retrievalPacket.Success;
        StateHasChanged();
    }

    protected override Task OnInitializedAsync()
    {
        authPacket = new AuthPacket();
        userform = new UserForm();
        keyForm = new KeyForm() {key = "InstanceKey"};
        client = ClientFactory.CreateClient();
        retrievalPacket = new RetrievalPacket() {AuthPacket = authPacket, Ip = "999.999.999.999:9999"};
        aliasDisplay = false;
        aliasList = new List<string>();
        return base.OnInitializedAsync();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpClientFactory ClientFactory { get; set; }
    }
}
#pragma warning restore 1591
