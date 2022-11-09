import { Outlet, Link } from "react-router-dom"
import { useNavigate } from "react-router-dom"

export const FrontLayout = () => {
    return (
        <>
        <header>
            <menu>
                <li><a href="/swagger">Swagger</a></li>
                <li><Link to="/users">Users</Link></li>
                <li><Link to="/account/login">Login</Link></li>
                <li><Link to="/account/register">Register</Link></li>
            </menu>
        </header>
        <main>
            <Outlet />
        </main>
        </>
    
    );
};

export default FrontLayout;