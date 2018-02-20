// tslint:disable-next-line
import URLSearchParams from "url-search-params";
import Axios from "axios";

class OAuth2Client {
    private readonly _authorizationEndPoint: string;
    private readonly _provider: string;
    private readonly _tokenEndPoint: string;
    private readonly _userInfoEndPoint: string;
    private readonly _userProfileFields: 
        string = ":(id,first-name,last-name,headline,location:(name),industry,summary,picture-url,email-address,phone-numbers,main-address)";
    
    constructor (authorizationEndpoint: string, provider: string, tokenEndPoint: string, userInfoEndPoint: string) {
        this._authorizationEndPoint = authorizationEndpoint;
        this._provider = provider;
        this._tokenEndPoint = tokenEndPoint;
        this._userInfoEndPoint = userInfoEndPoint;
    }

    GetAuthorizationEndPoint(): string {
        return this._authorizationEndPoint;
    }

    GetClientID(requestUrl: string): string {
        Axios({
            method: 'GET',
            url: requestUrl
        }).then(function(response) {
            return response.data;
        }).catch(function(error){
            console.log(error);
        });
        return "";
    }

    GetClientSecret(requestUrl: string): string {
        Axios({
            method: 'GET',
            url: requestUrl
        }).then(function(response) {
            return response.data;
        }).catch(function(error){
            console.log(error);
        });
        return "";
    }

    GetProvider(): string {
        return this._provider;
    }

    GetServiceLoginUrl(returnUrl: string): string {
        let serviceLoginUrl = this.GetAuthorizationEndPoint();
        let queryParams = new URLSearchParams();
        queryParams.append("response_type", "code");
        queryParams.append("client_id", this.GetClientID("https://localhost:44313/LinkedIn/GetClientID"));
        queryParams.append("redirect_uri", encodeURI(returnUrl));
        queryParams.append("state", "__provider__=" + this.GetProvider());
        return serviceLoginUrl + queryParams.toString();
    }

    GetVerificationUrl(): string {
        let verificationUrl = this.GetVerificationUrl();
        return "";
    }

    RequestAuthorization(): void {
        Axios({
            method: 'GET',
            url: this.GetServiceLoginUrl("")
        });
    }

    VerifyAuthentication(code: string, returnUrl: string): void {
        Axios({
            method: 'POST',
            url: this.GetVerificationUrl(),
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
                "Host": this.GetProvider()
            },
            data: {
                "grant_type": "authorization_code",
                "code": code,
                "redirect_uri": returnUrl,
                "client_id": this.GetClientID,
                "client_secret": this.GetClientSecret
            }
        }).then(function(response) {
            console.log(response.data);
        }).catch(function(error) {
            console.log(error);
        });
        console.log("");
    }
}