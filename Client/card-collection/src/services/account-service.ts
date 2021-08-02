import { EventEmitter, Injectable, Output } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

// import { environment } from '@environments/environment';
import { User } from 'src/models/user';

@Injectable({ providedIn: 'root' })
export class AccountService {

    url: string = "https://localhost:44345"

    httpOptions = {headers: new HttpHeaders({"Content-Type" : "application/json"})}

    private userSubject: BehaviorSubject<User>;
    public user: Observable<User>;
    @Output() loggedInEvent : EventEmitter<boolean> = new EventEmitter<boolean>();

    constructor(
        
        private router: Router,
        private http: HttpClient
    ) {
        this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('user') || '{}'));
        this.user = this.userSubject.asObservable();

    }

    public get userValue(): User {
        return this.userSubject.value;
    }

    login(username: string, password: string) {
        return this.http.post<User>(this.url + `/user/authenticate`, { username, password })
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('user', JSON.stringify(user));
                this.userSubject.next(user);
                return user;
            }));
    }

    logout() {
        // remove user from local storage and set current user to null
        localStorage.removeItem('user');
        this.userSubject == null;
        this.router.navigate(['/account/login']);
    }

    register(user: User) {
        return this.http.post(this.url + `/user/register`, user);
    }

    getAll() {
        return this.http.get<User[]>(this.url + `/user`);
    }

    getById(id: string) {
        return this.http.get<User>(this.url + `/user/${id}`);
    }

    update(id : string, params: object) {
        return this.http.put(this.url + `/user/${id}`, params)
            .pipe(map(x => {
                // update stored user if the logged in user updated their own record
                if (id == this.userValue.id) {
                    // update local storage
                    const user = { ...this.userValue, ...params };
                    localStorage.setItem('user', JSON.stringify(user));

                    // publish updated user to subscribers
                    this.userSubject.next(user);
                }
                return x;
            }));
    }

    delete(id: string) {
        return this.http.delete(this.url + `/users/${id}`)
            .pipe(map(x => {
                // auto logout if the logged in user deleted their own record
                if (id == this.userValue.id) {
                    this.logout();
                }
                return x;
            }));
    }

    isLoggedIn() : boolean {
       let u = JSON.parse(localStorage.getItem('user') || '{}')
        if (u.token != null) {
            return true;
        }
        else {
            return false;
        }
        
    }

  
}