import { useForm } from "react-hook-form"

export const Login = () => {
    const { register, handleSubmit, watch, formState: { errors } } = useForm();
    const onSubmit = data => console.log(data);
    return (
        <>
        <h1>Login</h1>
        <form onSubmit={handleSubmit(onSubmit)}>
            <div>
                <label>Username</label>
                <input defaultValue="user" {...register("username")} />
            </div>
            <div>
                <label>Password</label>
                <input type="password" {...register("password")} />
            </div>
            <div>
                <button type="submit">Login</button>
            </div>
        </form>
        </>
    );
}

export default Login;