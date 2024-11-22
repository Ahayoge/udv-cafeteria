import { Outlet } from "react-router-dom"
import s from './Container.module.css'

const Container = () => {
  return (
    <div className={s.container}>
        <Outlet/>
    </div>
  )
}

export default Container