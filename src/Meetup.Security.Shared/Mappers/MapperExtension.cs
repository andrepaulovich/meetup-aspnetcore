using AutoMapper;

namespace Meetup.Security.Shared.Mappers
{
    public static class MapperExtension
    {
        /// <summary>
        /// Converte uma entidade/dto em dto/entidade utilizando Auto Mapper
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <returns>Extension de Mapper</returns>
        public static T To<T>(this object from)
        {
            if (from == null)
            {
                return default(T);
            }

            return Mapper.Map<T>(from);
        }
    }
}
