import { Outlet } from "react-router-dom"
import { useNavigate } from "react-router-dom"

export const FrontLayout = () => {
    return (
        <>
        <header>
            <menu>
                <li><a href="/swagger">Swagger</a></li>
            </menu>
        </header>
        <main>
            <Outlet />
        </main>
        </>
    
    );
};

export default FrontLayout;