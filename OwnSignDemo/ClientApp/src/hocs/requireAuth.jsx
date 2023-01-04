import React from 'react';
import { useAuthContext } from "../providers/AuthProvider";

export const requireAuth = (WrappedComponent) => props  => {
    const [{accessToken}] = useAuthContext();
    if (accessToken === null) {
        return <p>I dont know You</p>;
    } else {
        return(
            <WrappedComponent {...props}>
                {props.children}
            </WrappedComponent>
        );
    }
    
}

export default requireAuth;