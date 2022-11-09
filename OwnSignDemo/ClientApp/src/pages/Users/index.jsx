import { Outlet, Link } from "react-router-dom"
import { useNavigate } from "react-router-dom"

export const UsersLayout = () => {
    return (
        <>
        <header>
            <menu>
                <li><Link to="/">Home</Link></li>
                <li><Link to="/users">Users</Link></li>
                <li><Link to="/users/create">New</Link></li>
            </menu>
        </header>
        <main>
            <Outlet />
        </main>
        </>
    
    );
};

export default UsersLayout;