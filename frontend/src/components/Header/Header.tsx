import s from './Header.module.css';

const Header = () => {
    return (
        <header className={s.header}>
            <ul className={`${s.nav_list} flex`}>
                <li className={s.nav_item}>
                    <a href='' className={`${s.nav_link} flex`}>
                        Ссылка на что-то
                    </a>
                </li>
                <li className={s.nav_item}>
                    <a href='' className={`${s.nav_link} flex`}>
                        Ссылка на что-то
                    </a>
                </li>
                <li className={s.nav_item}>
                    <a href='' className={`${s.nav_link} flex`}>
                        Ссылка на что-то
                    </a>
                </li>
                <li className={s.nav_item}>
                    <a href='' className={`${s.nav_link} flex`}>
                        Ссылка на что-то
                    </a>
                </li>
            </ul>
        </header>
    );
};

export default Header;
